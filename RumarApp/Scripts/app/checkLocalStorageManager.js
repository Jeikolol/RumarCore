var CheckManager = function (datatableObject) {
    var checkSecuence = 0;
    var secretConstant = "CK_SQ_";
    var getRowInformationForDataTable = function (check) {

        var btnDelete = "<button type='button' " +
            "class='ladda-button btn btn-danger deleteRow btn-sm action-btn' " +
            "data-toggle='tooltip' data-placement='left'" +
            "data-style='zoom-in'title='Eliminar'><i class='fa fa-ban'></i></button>";
        var btnEdit = "<button type='button' " +
            "class='ladda-button btn btn-info editRow btn-sm  action-btn' " +
            "data-toggle='modal' data-target='#editCheque' data-placement='right'" +
            "data-style='zoom-in' title='Editar'><i class='fa fa-pencil-square-o'></i></button>"

        return [
            check.Id,
            check.AccountInformation.BankName,
            check.CheckInformation.CheckNumber,
            check.SenderInformation.FullName,
            check.CheckInformation.Amount,
            `${btnDelete} ${btnEdit}`
        ];
    };
    var getId = function () {
        checkSecuence++;
        return secretConstant + checkSecuence;
    };


    this.save = function (check) {

        if (check.Id === 0) {
            check.Id = getId();
            datatableObject.row
                .add(getRowInformationForDataTable(check))
                .draw();

        } else {
            datatableObject.row
                .add(getRowInformationForDataTable(check))
                .draw();

        }
        localStorage.setItem(check.Id, JSON.stringify(check));
    }

    this.getById= function (checkId) {
        return JSON.parse(localStorage.getItem(checkId));
    }

    this.deleteById = function (checkId) {
        localStorage.removeItem(checkId);
    }

    this.getAll = function() {

        var archive = [],
            keys = Object.keys(localStorage),
            i = 0, key;
        for (; key = keys[i]; i++) {
            if (key.indexOf(secretConstant) !== -1) {
                archive.push(localStorage.getItem(key));
            }
        }

        return archive;
    }

    this.deleteAll = function() {
        var keys = Object.keys(localStorage),
            i = 0, key;
        for (; key = keys[i]; i++) {
            if (key.indexOf(secretConstant) !== -1) {
                localStorage.removeItem(key);
            }
        }

    }
}