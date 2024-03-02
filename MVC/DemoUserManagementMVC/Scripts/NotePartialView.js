document.getElementById('addNoteButton').addEventListener('click', addNote);

var currentPageNote = 1;
var sortExpressionNote = "ID";
var sortDirectionNote = "ASC";

$(document).ready(function () {
    loadNotes(currentPageNote, sortExpressionNote, sortDirectionNote);
});


function loadNotes(page, sortExpressionNote, sortDirectionNote) {


    $.ajax({
        url: "/PartialView/GetNoteData",
        type: 'POST',
        data: { objectID: objectID, objectType: objectType, page: page, sortExpression: sortExpressionNote, sortDirection: sortDirectionNote },
        success: function (result) {


            $('#notesTable tbody').empty();
            $.each(result.notes, function (index, note) {
                var date = new Date(parseInt(note.DateTime.substr(6)));
                var formattedDateTime = NoteformatDate(date);

                var row = '<tr>' +
                    '<td>' + note.ID + '</td>' +
                    '<td>' + note.ObjectID + '</td>' +
                    '<td>' + note.ObjectType + '</td>' +
                    '<td>' + note.Note + '</td>' +
                    '<td>' + formattedDateTime + '</td>' +
                    '</tr>';
                $('#notesTable tbody').append(row);
            });
            currentPageNote = page;
            generatePageNumbersNote(result.totalPages);
        },
        error: function () {
            alert('Error loading notes.');
        }
    });

}


function NoteformatDate(date) {
    var hours = date.getHours();
    var minutes = date.getMinutes();
    var ampm = hours >= 12 ? 'PM' : 'AM';
    hours = hours % 12;
    hours = hours ? hours : 12;
    minutes = minutes < 10 ? '0' + minutes : minutes;
    var strTime = hours + ':' + minutes + ' ' + ampm;
    return (date.getMonth() + 1) + '/' + date.getDate() + '/' + date.getFullYear() + ' ' + strTime;
}


function addNote(event) {
    event.preventDefault();
    var newNote = $('#newNote').val();
    if (newNote.trim() !== "") {
        $.ajax({
            url: "/PartialView/AddNote",
            type: 'POST',
            data: { objectID: objectID, objectType: objectType, note: newNote },
            success: function (result) {
                if (result.success) {
                    loadNotes(currentPageNote, sortExpressionNote, sortDirectionNote);
                    $('#newNote').val('');
                }
               
            },

        });
    }
}

function sortTableNote(expression) {
    if (sortExpressionNote === expression) {
        sortDirectionNote = sortDirectionNote === "ASC" ? "DESC" : "ASC";
    }
    else {
        sortDirectionNote = "ASC";
    }
    sortExpressionNote = expression;
    loadNotes(currentPageNote, sortExpressionNote, sortDirectionNote);
}

function generatePageNumbersNote(totalPages) {

    $('#pageNumbersNote').empty();
    for (var i = 1; i <= totalPages; i++) {
        var buttonClass = i === currentPageNote ? 'pageNumber btn btn-primary mr-1' : 'pageNumber btn btn-outline-dark mr-1';
        $('#pageNumbersNote').append('<button class="' + buttonClass + '" data-page="' + i + '">' + i + '</button>');
    }
    $('#pageNumbersNote').on('click', '.pageNumber', function (event) {
        event.preventDefault();
        var page = $(this).data('page');
        loadNotes(page, sortExpressionNote, sortDirectionNote);
    });
}
