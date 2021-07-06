
var WizardSubmitHelper = function() {

    this.initializeFormData = function(context) {
        var formData = setCheckOutputEntityId($(context).serialize());
        formData = setTransferenceSenderEntityId(formData);
        formData = setTransferenceOutputEntityId(formData);
        return formData;
    }

    function setCheckOutputEntityId(formData) {
        var entityId = $("#CheckOutputBeneficiaryEntityId").val();
        if (entityId) {
            return formData + "&CheckOutputInformation.EntityId=" + entityId;
        }
        return formData;
    }

    function setTransferenceSenderEntityId(formData) {
        var entityId = $("#TransferenceSenderEntityId").val();
        if (entityId) {
            return formData + "&TransferenceSenderInformation.EntityId=" + entityId;
        }
        return formData;
    }

    function setTransferenceOutputEntityId(formData) {
        var entityId = $("#TransferenceModalEntityId").val();
        if (entityId) {
            return formData + "&TransferenceInformation.EntityId=" + entityId;
        }
        return formData;
    }

    this.removeHash = function () { 
        history.pushState("", document.title, window.location.pathname
            + window.location.search);
    }

    this.disableTransferenceInputElements = function () {
        changeStatusOnTransferenceInputTransferenceInformationElements(true);
    }

    this.enableTransferenceInputElements = function() {
        changeStatusOnTransferenceInputTransferenceInformationElements(false);
    }

    function changeStatusOnTransferenceInputTransferenceInformationElements(booleanStatus) {
        var htmlElements = $(".transference-input-transference-information-step").children()[1];
        $(htmlElements).find(":input").attr("disabled", booleanStatus);
    }
}


