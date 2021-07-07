var CustomerCheckHolderManager = function (datatableObject) {

    var checkSecuence = 0;
    var customerHolderSequence = 0;
    var secretConstant = "CHLDR_SQ_";
    var getRowInformationForDataTable = function (customerCheckHolder) {
        var btnDelete = "<button type='button' " +
            "class='ladda-button btn btn-danger deleteRow btn-sm action-btn' " +
            "data-toggle='tooltip' data-placement='left'" +
            "data-style='zoom-in'title='Eliminar'><i class='fa fa-ban'></i></button>";
        var btnEdit = "<button type='button' " +
            "class='ladda-button btn btn-info editRow btn-sm  action-btn' " +
            "data-toggle='modal' data-target='#editCheque' data-placement='right'" +
            "data-style='zoom-in' title='Editar'><i class='fa fa-pencil-square-o'></i></button>"

        return [
            customerCheckHolder.localStorageUniqueId,
            customerCheckHolder.AccountInformation.BankName,
            customerCheckHolder.CheckInformation.CheckNumber,
            customerCheckHolder.SenderInformation.FullName,
            customerCheckHolder.CheckInformation.Amount,
            `${btnDelete} ${btnEdit}`
        ];
    };



    this.getAccountInformation = function (customerCheckHolderId) {
        var records = getAllParsed();
        var result = records.find(x => x.Id == customerCheckHolderId);
        return {
            AccountNumber: result.AccountInformation.AccountNumber,
            BankCityName: result.AccountInformation.BankCityName,
            BankCountryId: result.AccountInformation.BankCountryId,
            BankId: result.AccountInformation.BankId,
            BankName: result.AccountInformation.BankName,
            CheckIsDoubleEndosed: result.AccountInformation.CheckIsDoubleEndosed
        }
    }

    this.getCustomerHolderListItems = function () {
        var allRecords = getAllParsed();
        return allRecords.map(x => {
            return {
                CustomerCheckHolderId: x.Id,
                FullName: x.SenderInformation.FullName,
                Identification: x.SenderInformation.Identification,
                EntityId: x.SenderInformation.EntityId
            }
        });
    }

    this.getBeneficiariesListItems = function (customerCheckHolderId) {
        var allRecords = getAllParsed();
        var singleRecord = allRecords.find(x => x.Id == customerCheckHolderId);
        return singleRecord.Beneficiaries.map(x => {
            return {
                CustomerCheckHolderId: x.CustomerCheckHolderId,
                FullName: x.FullName,
                Identification: x.Identification,
                EntityId: x.EntityId
            }
        });
    }

    this.getSenderInformation = function (customerCheckHolderId) {
        var records = getAllParsed();
        var result = records.find(x => x.Id == customerCheckHolderId);
        return {
            IdentificationTypeId: result.SenderInformation.IdentificationTypeId,
            FirstName: result.SenderInformation.FirstName,
            LastName: result.SenderInformation.LastName,
            Identification: result.SenderInformation.Identification,
            IdentificationCountryId: result.SenderInformation.IdentificationCountryId,
            EconomicActivityId: result.SenderInformation.EconomicActivityId,
            EconomicActivityDescription: result.SenderInformation.EconomicActivityDescription,
            Email: result.SenderInformation.Email,
            Phone: result.SenderInformation.Phone,
            Notes: result.SenderInformation.Notes,
            EntityId: result.SenderInformation.EntityId,
            Relationship: result.SenderInformation.Relationship,
            CustomerCheckHolderId: result.Id

        }
    }

    this.getBeneficiaryInformation = function (customerCheckHolderId) {
        var records = getAllParsed();
        var singleRecord = records.find(x => x.Id == customerCheckHolderId);
        var result = singleRecord.Beneficiaries.find(x => x.CustomerCheckHolderId == customerCheckHolderId);
        return {
            IdentificationTypeId: result.IdentificationTypeId,
            FirstName: result.FirstName,
            LastName: result.LastName,
            Identification: result.Identification,
            IdentificationCountryId: result.IdentificationCountryId,
            EconomicActivityId: result.EconomicActivityId,
            EconomicActivityDescription: result.EconomicActivityDescription,
            Email: result.Email,
            Phone: result.Phone,
            Notes: result.Notes,
            EntityId: result.EntityId,
            Relationship: result.Relationship,
            CustomerCheckHolderId: result.CustomerCheckHolderId
        }
    }

    this.addCustomerCheckHolder = function (customerCheckHolder, checkInformation, beneficiaryInformation) {
        var checkHolderInfo = new CustomerCheckHolder(customerCheckHolder);
        checkHolderInfo.CheckInformation = checkInformation;

        var checkInfo = new CheckInformation(checkInformation, checkHolderInfo.Id);
        var beneficiaryInfo = new BeneficiaryInformation(beneficiaryInformation, checkHolderInfo.Id);
        checkHolderInfo.Checks.push(checkInfo);
        checkHolderInfo.Beneficiaries.push(beneficiaryInfo);

        save(checkHolderInfo);
    }

    this.addCheck = function (checkInformation, customerCheckHolderId) {
        var checkInfo = new CheckInformation(checkInformation, customerCheckHolderId);
        var customerCheckHolder = getSingleRecord(customerCheckHolderId);
        customerCheckHolder.Checks.push(checkInfo);
        customerCheckHolder.CheckInformation = checkInfo;
        save(customerCheckHolder);
    }



    this.addBeneficiary = function (beneficiaryInformation, customerCheckHolderId) {
        var beneficiaryInfo = new BeneficiaryInformation(beneficiaryInformation, customerCheckHolderId)
        var customerCheckHolder = getSingleRecord(customerCheckHolderId);
        customerCheckHolder.Beneficiaries.push(beneficiaryInfo);
        save(customerCheckHolder);

    }

    this.deleteAll = function () {
        var keys = Object.keys(localStorage),
            i = 0, key;
        for (; key = keys[i]; i++) {
            if (key.indexOf(secretConstant) !== -1) {
                localStorage.removeItem(key);
            }
        }
    }
    this.getAll = function () {

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

    this.setInitialCatalog = function (customerCheckHolders) {

        if (customerCheckHolders.CustomerCheckHolderMapper.length > 0) {

            for (var i = 0; i < customerCheckHolders.CustomerCheckHolderMapper.length; i++) {

                customerHolderSequence = customerCheckHolders.CustomerCheckHolderMapper[i].SenderInformation.EntityId;
                customerCheckHolders.CustomerCheckHolderMapper[i].Beneficiaries
                    .map(x => x.CustomerCheckHolderId = customerHolderSequence);

                customerCheckHolders.CustomerCheckHolderMapper[i].Id = `${customerHolderSequence}`;
                customerCheckHolders.CustomerCheckHolderMapper[i].Checks = [];
                if (!existCustomerCheckHolder(customerCheckHolders.CustomerCheckHolderMapper[i].Id)) {
                    saveWithoutDatatable(customerCheckHolders.CustomerCheckHolderMapper[i]);

                }
            }
        }
    }
    this.getCheckCount = function() {
       return datatableObject.data().count();
    };

    function existCustomerCheckHolder(customerCheckHolderId) {
        var records = getAllParsed();
        var result = records.find(x => x.Id == customerCheckHolderId);
        if (result) return true;
        return false;

    }

    function save(customerCheckHolder) {

        customerCheckHolder.localStorageUniqueId = `${secretConstant}${customerCheckHolder.Id}`;
        datatableObject.row.add(getRowInformationForDataTable(customerCheckHolder)).draw();
        localStorage.setItem(customerCheckHolder.localStorageUniqueId, JSON.stringify(customerCheckHolder));
    }
    function saveWithoutDatatable(customerCheckHolder) {
        customerCheckHolder.localStorageUniqueId = `${secretConstant}${customerCheckHolder.Id}`;
        localStorage.setItem(customerCheckHolder.localStorageUniqueId, JSON.stringify(customerCheckHolder));

    }

    //var getLocalStorageUniqueId = function () {
    //    uniqueIdSecuence++;
    //    return secretConstant + uniqueIdSecuence;
    //};


    //this.getCheckCount = function() {
    //    return globalChecks.length;
    //}

    //this.getTotalCheckAmount = function() {
    //    var total = 0;
    //    for (var i = 0; i < checks.length; i++) {
    //        var item = checks[i];
    //        total += (+item.Amount);
    //    }

    //}

    //this.deleteCheckById = function (checkId) {
    //    removeItem("Id", checkId, globalChecks);
    //}

    //TODO Remove this one
    //this.getById = function (checkId) {
    //    return JSON.parse(localStorage.getItem(checkId));
    //}

    //this.deleteById = function (checkId) {
    //    localStorage.removeItem(checkId);
    //}





    function getSingleRecord(customerCheckHolderId) {

        var allRecords = getAllParsed();

        //DO NOT CHANGE THIS TO === 
        var result = allRecords.find(x => x.Id == customerCheckHolderId);
        return result;

    }

    function getAllParsed() {

        var archive = [],
            keys = Object.keys(localStorage),
            i = 0, key;
        for (; key = keys[i]; i++) {
            if (key.indexOf(secretConstant) !== -1) {
                archive.push(JSON.parse(localStorage.getItem(key)));
            }
        }

        return archive;
    }


    function BeneficiaryInformation(benInfo, customerCheckHolderId) {
        benInfo.CustomerCheckHolderId = customerCheckHolderId;
        return benInfo;
    }

    function getCheckHolderId() {
        customerHolderSequence++;
        return customerHolderSequence;
    }

    function CustomerCheckHolder(mapObject) {
        return {
            Id: getCheckHolderId(),
            SenderInformation: mapObject.SenderInformation,
            AccountInformation: mapObject.AccountInformation,
            Beneficiaries: [],
            Checks: []
        }
    }

    function getCheckId() {
        checkSecuence++;
        return checkSecuence;
    }

    function CheckInformation(mapObject, customerCheckHolderId) {
        return {
            CustomerCheckHolderId: customerCheckHolderId,
            Id: getCheckId(),
            CheckNumber: mapObject.CheckNumber,
            Amount: +mapObject.Amount,
            CheckIsDoubleEndosed: mapObject.CheckIsDoubleEndosed 
        }
    }
    function removeItem(key, value, collection) {
        if (value == undefined)
            return;

        for (var i = 0; i < t.length; ++i) {
            if (collection[i][key] == value) {
                collection.splice(i, 1);
            }
        }
    }
}