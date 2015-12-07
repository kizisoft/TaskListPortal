'use strict';

app.factory('tasks', ['$resource', 'constants', function ($resource, constants) {
    var resource = $resource(constants.baseApiUrl + 'repos/:repoName/task/:id', {repoName: '@repoName', id: '@id'}, {
        'update': {
            method: 'PUT'
        }
    });

    function add(repoName, id, task) {
        return resource.save({repoName: repoName, id: id}, task).$promise;
    }

    function getAll(repoName) {
        return resource.query({repoName: repoName}).$promise;
    }

    function getById(repoName, id) {
        return resource.get({repoName: repoName, id: id}).$promise;
    }

    function update(repoName, id, task) {
        return resource.update({repoName: repoName, id: id}, task).$promise;
    }

    function remove(repoName, id) {
        return resource.delete({repoName: repoName, id: id}).$promise;
    }

    return {
        add: add,
        getAll: getAll,
        getById: getById,
        update: update,
        remove: remove
    };
}]);