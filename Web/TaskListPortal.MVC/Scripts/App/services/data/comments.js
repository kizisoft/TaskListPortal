'use strict';

app.factory('comments', ['$resource', 'constants', function ($resource, constants) {
    var resource = $resource(constants.baseApiUrl + 'repos/:repoName/task/:taskId/comment/:id', {
        repoName: '@repoName',
        taskId: '@taskId',
        id: '@id'
    });

    function add(repoName, taskId, comment) {
        return resource.save({repoName: repoName, taskId: taskId}, comment).$promise;
    }

    function getAll(repoName, taskId) {
        return resource.query({repoName: repoName, taskId: taskId}).$promise;
    }

    return {
        add: add,
        getAll: getAll
    };
}]);