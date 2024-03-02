var currentPageDocument = 1;
var sortExpressionDocument = "ID";
var sortDirectionDocumnet = "ASC";

$(document).ready(function () {
    loadDocumentTypes();
    loadDocuments(currentPageDocument, sortExpressionDocument, sortDirectionDocumnet);
    $('#btnUpload').click(uploadDocument);

});

function loadDocumentTypes() {
    $.ajax({
        url: "/PartialView/GetDocumentTypes",
        type: 'GET',
        data: { objectType: objectType },
        success: function (result) {
            var ddlDocumentType = $('#ddlDocumentType');
            ddlDocumentType.empty();
            ddlDocumentType.append($('<option></option>').val("").text("Select Document")); // Default option
            $.each(result, function (index, item) {
                ddlDocumentType.append($('<option></option>').val(item.DocumentId).text(item.DocumentTypeName));
            });
            
        }
    });
}

function loadDocuments(page,sortExpressionDocument, sortDirectionDocumnet) {
    $.ajax({
        url: "/PartialView/GetDocumentData",
        type: 'GET',
        data: { objectID: objectID, objectType: objectType, page: page, sortExpression: sortExpressionDocument, sortDirection: sortDirectionDocumnet },
        success: function (result) {
            var tableBody = $('#documentTable tbody');
            tableBody.empty();
            $.each(result.documents, function (index, item) {
                var date = new Date(parseInt(item.DateTime.substr(6)));
                var formattedDateTime = DocumentformatDate(date);

                var row = $('<tr>');
                row.append($('<td>').text(item.ID));
                row.append($('<td>').text(item.DocumentType));
                row.append($('<td>').text(item.DocumentOriginalName));
                row.append($('<td>').text(formattedDateTime));
                var downloadLink = $('<a>').attr('href', '/File/Download/?documentId=' + item.ID).addClass('btn btn-primary btn-sm').text('Download');
                var downloadBtn = $('<td>').append(downloadLink);
                row.append($('<td>').append(downloadBtn));
                tableBody.append(row);
            });
            currentPageDocument = page;
            generatePageNumbersDocument(result.totalPages);
        }
    });
}

function DocumentformatDate(date) {
    var hours = date.getHours();
    var minutes = date.getMinutes();
    var ampm = hours >= 12 ? 'PM' : 'AM';
    hours = hours % 12;
    hours = hours ? hours : 12;
    minutes = minutes < 10 ? '0' + minutes : minutes;
    var strTime = hours + ':' + minutes + ' ' + ampm;
    return (date.getMonth() + 1) + '/' + date.getDate() + '/' + date.getFullYear() + ' ' + strTime;
}

function uploadDocument(event)
{
    event.preventDefault();
    var formData = new FormData();
    var fileInput = document.getElementById('document');
    formData.append('file', fileInput.files[0]);

    var uniqueFileName = '';

    $.ajax({
        type: 'POST',
        url: "/File/Upload",
        data: formData,
        contentType: false,
        processData: false,
        success: function (response)
        {
            uniqueFileName = response;
            if (uniqueFileName) {
                $.ajax({
                    type: 'POST',
                    url: "/PartialView/StoreDocument",
                    data: {
                        objectID: objectID,
                        objectType: objectType,
                        documentType: $('#ddlDocumentType').val(),
                        documentOriginalName: fileInput.files[0].name,
                        documentUniqueName: uniqueFileName
                    },
                    success: function (response) {
                        if (response.success) {
                            loadDocuments(currentPageDocument, sortExpressionDocument, sortDirectionDocumnet);
                        }
                    },
                    error: function (error) {
                        alert('Error uploading file.');
                    }
                });
            }
            
        },
        error: function (error) {
            alert('Error uploading file.');
        }
    });

    
}

function sortTableDocument(expression) {
    if (sortExpressionDocument === expression) {
        sortDirectionDocumnet = sortDirectionDocumnet === "ASC" ? "DESC" : "ASC";
    }
    else {
        sortDirectionDocumnet = "ASC";
    }
    sortExpressionDocument = expression;
    loadDocuments(currentPageDocument, sortExpressionDocument, sortDirectionDocumnet);
}

function generatePageNumbersDocument(totalPages) {

    $('#pageNumbersDocument').empty();
    for (var i = 1; i <= totalPages; i++) {
        var buttonClass = i === currentPageDocument ? 'pageNumberDocument btn btn-primary mr-1' : 'pageNumberDocument btn btn-outline-dark mr-1';
        $('#pageNumbersDocument').append('<button class="' + buttonClass + '" data-page="' + i + '">' + i + '</button>');
    }
    $('#pageNumbersDocument').on('click', '.pageNumberDocument', function (event) {
        event.preventDefault();
        var page = $(this).data('page');
        loadDocuments(page, sortExpressionDocument, sortDirectionDocumnet);
    });
}
