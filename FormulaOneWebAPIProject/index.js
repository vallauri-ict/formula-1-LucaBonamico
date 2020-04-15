let app;

$(function () {
    app = new Vue({
        el: "#div",
        data: {
            drivers: [],
            teams: [],
            circuits: [],
            rows: [],
            stringa: '',
            idRicerca: '',
            error: ''
        },
        methods: {
            driversClick: getDrivers,
            teamsClick: getTeams,
            circuitsClick: getCircuits,
            ricerca: ricercaElemento
        }
    });
});

function getDrivers() {
    clear();
    app.stringa = 'drivers';
    $.getJSON('/api/drivers').done(
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
    $.getJSON('/api/teams').done(
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
    $.getJSON('/api/circuits').done(
        function (data) {
            console.log(data);
            app.circuits = data;
            app.rows = [];
            for (let i = 0; i < app.circuits.length; i += 3) {
                app.rows[i / 3] = app.circuits.slice(i, i + 3);
            }
        });
}

function ricercaElemento() {
    let elem;
    app.error = '';

    if (app.idRicerca == '') {
        for (let i = 0; i < app[app.stringa].length; i += 3) {
            app.rows[i / 3] = app[app.stringa].slice(i, i + 3);
        }
    } else {
        elem = app[app.stringa].find(item => item.id == app.idRicerca);
        if (elem == undefined)
            app.error = app.stringa.substring(0, app.stringa.length - 1) + ' not found';
        else
            app.rows = [[elem]];
    }
}

function clear() {
    app.error = '';
    app.idRicerca = '';
}
