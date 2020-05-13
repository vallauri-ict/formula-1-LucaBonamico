let app;

$(function () {
    app = new Vue({
        el: "#div",
        data: {
            drivers: [],
            teams: [],
            circuits: [],
            racesScores: [],
            races: [],
            rows: [],
            driverDetail: [],
            teamDetail: [],
            stringa: '',
            raceId: '',
            error: ''
        },
        methods: {
            driversClick: getDrivers,
            teamsClick: getTeams,
            circuitsClick: getCircuits,
            racesscoresClick: getRacesScores,
            raceResultsClick: getRaceResults,
            infoClik: ricercaElemento,
            backClick: back
        }
    });
});

function getDrivers() {
    clear();
    app.stringa = 'drivers';
    $.getJSON('/api/drivers/list').done(
        function (data) {
            console.log(data);
            app.drivers = data;
            app.rows = [];
            for (let i = 0; i < app.drivers.length; i += 3) {
                app.rows[i / 3] = app.drivers.slice(i, i + 3);
            }
        });
}

function getTeams() {
    clear();
    app.stringa = 'teams';
    $.getJSON('/api/teams/list').done(
        function (data) {
            console.log(data);
            app.teams = data;
            app.rows = [];
            for (let i = 0; i < app.teams.length; i += 3) {
                app.rows[i / 3] = app.teams.slice(i, i + 3);
            }
    });
}

function getCircuits() {
    clear();
    app.stringa = 'circuits';
    $.getJSON('/api/circuits/list').done(
        function (data) {
            console.log(data);
            app.circuits = data;
            app.rows = [];
            for (let i = 0; i < app.circuits.length; i += 3) {
                app.rows[i / 3] = app.circuits.slice(i, i + 3);
            }
        });
}

function getRacesScores() {
    clear();
    app.stringa = 'racesScores';
    $.getJSON('/api/races/list').done(
        function (data) {
            console.log(data);
            app.races = data;
        });
}

function getRaceResults() {
    console.log(app.raceId);
    $.getJSON('/api/racesScores/' + app.raceId).done(
        function (data) {
            console.log(data);
            app.racesScores = data;
        });
}

function ricercaElemento(id) {
    app.rows = [];
    app.error = '';

    console.log(id);

    $.getJSON('/api/' + app.stringa + '/' + id).done(
        function (data) {
            console.log(data);
            if (app.stringa == 'drivers') {
                app.driverDetail = data;
                app.stringa = 'driverDetail';
            }
            else {
                app.teamDetail = data;
                app.stringa = 'teamDetail';
            }
        }
    ).fail(function (data) {
        if (data.status == 404)
            app.error = app.stringa + ' not found';
    });
}

function back() {
    clear();
    switch (app.stringa) {
        case "driverDetail":
            app.stringa = "drivers";
            app.driverDetail = [];
            getDrivers();
            break;
        case "teamDetail":
            app.stringa = "teams";
            app.teamDetail = [];
            getTeams();
            break;
    }
}

function clear() {
    app.error = '';
    app.idRicerca = '';
}