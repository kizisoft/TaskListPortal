'use strict';

app.controller('HomeCtrl', ['$scope', '$location', '$sce', 'tasks', 'comments', 'notifier', function ($scope, $location, $sce, tasks, comments, notifier) {
    var currentTaskId,
        isLeftDisabled = false,
        isRightDisabled = false,
        repoId = $('#repoId').val(),
        repoName = $('#repoName').val(),
        authorId = $('#authorId').val(),
        authorName = $('#authorName').val();

    function getComments(comments) {
        var result = [];
        for (var i = 0, length = comments.length; i < length; i += 1) {
            result.push({
                Id: comments[i].Id,
                Content: $sce.trustAsHtml(comments[i].Content),
                AuthorId: comments[i].AuthorId,
                Author: comments[i].Author,
                CreatedOn: comments[i].CreatedOn,
                ModifiedOn: comments[i].ModifiedOn
            });
        }
        return result;
    }

    tasks.getAll(repoName)
        .then(function (tasks) {
            $scope.tasks = tasks;
            $scope.hasTasks = !!tasks[0];
        }, function (err) {
            notifier.notifyError('Can not get list of tasks!<br/>' + (!!err.data ? err.data.Message : ''));
        });

    $scope.showTaskDetails = function (task) {
        if (!isLeftDisabled) {
            var $element = $('#' + task.Id);
            if (!$element.hasClass('current')) {
                $('.accordion.current').removeClass('current').find('.details').addClass('hidden');
            }

            $element.toggleClass('current').find('.details').toggleClass('hidden');
            $scope.showComments = $element.hasClass('current');
            $scope.comments = getComments(task.Comments);
            currentTaskId = task.Id;
        } else {
            notifier.notifyInfo('Create new comment is not finished!');
        }
    };

    $scope.toggleTaskForm = function (task, isEdit) {
        if (!isLeftDisabled) {
            if (!!task) {
                $scope.task = {
                    id: task.Id,
                    name: task.Name,
                    description: task.Description,
                    status: '' + task.Status
                };
            } else {
                $scope.task = { status: '0' };
            }

            $scope.isEdit = isEdit;
            $('#new-task-btn').toggleClass('hidden');
            var $taskRoot = $('#new-task-root');
            $taskRoot.toggleClass('hidden');
            isRightDisabled = !$taskRoot.hasClass('hidden');
        } else {
            notifier.notifyInfo('Create new comment is not finished!');
        }
    };

    $scope.createEditTask = function (task) {
        if ($scope.isEdit) {
            $scope.editTask(task);
        } else {
            $scope.createTask(task);
        }
    };

    $scope.createTask = function (task) {
        tasks.add(repoName, repoId, task)
            .then(function (taskDb) {
                $scope.toggleTaskForm(null, false);
                notifier.notifySuccess('The task was created!');
                $location.path('/home');
            }, function (err) {
                notifier.notifyError('Can not create new task!<br/>' + (!!err.data ? err.data.Message : ''));
            });
    };

    $scope.deleteTask = function (task) {
        if (!isLeftDisabled) {
            if (window.confirm('The task will be deleted. Are you sure?')) {
                tasks.remove(repoName, task.Id)
                    .then(function () {
                        notifier.notifySuccess('The task was deleted!');
                        $location.path('/home');
                    }, function (err) {
                        notifier.notifyError('Can not delete a task!<br/>' + (!!err.data ? err.data.Message : ''));
                    });
            }
        } else {
            notifier.notifyInfo('Create new comment is not finished!');
        }
    };

    $scope.editTask = function (task) {
        tasks.update(repoName, task.id, task)
            .then(function (taskDb) {
                $scope.toggleTaskForm(null, false);
                notifier.notifySuccess('The task was modified!');
                $location.path('/home');
            }, function (err) {
                notifier.notifyError('Can not modify the task!<br/>' + (!!err.data ? err.data.Message : ''));
            });
    };

    $scope.toggleCommentForm = function () {
        if (!isRightDisabled) {
            isLeftDisabled = !isLeftDisabled;
            $scope.comment = { content: '' };
            $('#new-comment-btn').toggleClass('hidden');
            $('#new-comment-root').toggleClass('hidden');
        } else {
            notifier.notifyInfo('Create new task is not finished!');
        }
    };

    $scope.createComment = function (comment) {
        comment.authorId = authorId;
        comment.authorName = authorName;
        comments.add(repoName, currentTaskId, comment)
            .then(function () {
                $scope.toggleCommentForm();
                comments.getAll(repoName, currentTaskId)
                    .then(function (commentsDb) {
                        $scope.comments = getComments(commentsDb);
                        notifier.notifySuccess('New comment was created!');
                    }, function (err) {
                        notifier.notifyError('Can not modify the task!<br/>' + (!!err.data ? err.data.Message : ''));
                    });
            }, function (err) {
                notifier.notifyError('Can not create a comment!<br/>' + (!!err.data ? err.data.Message : ''));
            });
    };
}]);