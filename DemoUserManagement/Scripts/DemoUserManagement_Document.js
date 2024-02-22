function uploadDocument() {
    var formData = new FormData();
    var fileInput = document.getElementById('document');
    formData.append('file', fileInput.files[0]);

    var uniqueFileName = '';

    $.ajax({
        type: 'POST',
        url: 'UploadFileHandler.ashx',
        data: formData,
        contentType: false,
        processData: false,
        async: false, 
        success: function (response) {
            uniqueFileName = response;
        },
        error: function (error) {
            alert('Error uploading file.');
        }
    });

    if (uniqueFileName) {
        $.ajax({
            type: 'POST',
            url: 'LogIn.aspx/StoreDocument',
            data: JSON.stringify({
                objectID: document.getElementById('hdnObjectID').value,
                objectType: document.getElementById('hdnObjectType').value,
                documentType: document.getElementById('hdnDocumentType').value,
                documentOriginalName: fileInput.files[0].name,
                documentUniqueName: uniqueFileName
            }),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (response) {
                alert('Document uploaded successfully.');
            },
            error: function (error) {
                alert('Error uploading document.');
            }
        });
    }

    return true;
}
