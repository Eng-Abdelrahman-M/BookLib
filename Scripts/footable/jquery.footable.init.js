/**
 * Theme: Metrica - Responsive Bootstrap 4 Admin Dashboard
 * Author: Mannatthemes
 * Footable Js
 */

$(function () {
    "use strict";

    /*Init FooTable*/
    $('#footable-1,#footable-2').footable();

    /*Editing FooTable*/
    var $modal = $('#editor-modal'),
        $editor = $('#editor'),
        $editorTitle = $('#editor-title'),
        ft = FooTable.init('#footable-3', {
            editing: {
                alwaysShow: true,
                enabled: true,
                allowEdit: false,
                allowDelete: false,
                addRow: function () {
                    $modal.removeData('row');
                    $editor[0].reset();
                    $editorTitle.text('Add a new row');
                    $modal.modal('show');
                }
                //editRow: function (row) {
                //    var values = row.val();
                //    $editor.find('#id').val(values.id);
                //    $editor.find('#bookName').val(values.bookName);
                //    $editor.find('#authorName').val(values.authorName);
                //    $editor.find('#allNumber').val(values.allNumber);
                //    $editor.find('#availableNumber').val(values.availableNumber);

                //    $modal.data('row', row);
                //    $editorTitle.text('Edit row #' + values.id);
                //    $modal.modal('show');
                //},
                //deleteRow: function (row) {
                //    if (confirm('Are you sure you want to delete the row?')) {
                //        row.delete();
                //    }
                //}
            }
        }),
        uid = 10;

    $editor.on('submit', function (e) {
        if (this.checkValidity && !this.checkValidity()) return;
        e.preventDefault();
        var row = $modal.data('row'),
            values = {
                id: $editor.find('#id').val(),
                bookName: $editor.find('#bookName').val(),
                authorName: $editor.find('#authorName').val(),
                allNumber: $editor.find('#allNumber').val(),
                availableNumber: $editor.find('#allNumber').val()
            };
        addBook(values);
        if (row instanceof FooTable.Row) {
            row.val(values);
        } else {
            values.id = uid++;
            ft.rows.add(values);
        };
        $modal.modal('hide');
    });



});


$(document).ready(function () {
    $(".select2").select2({
        width: '100%'
    });
    $('#borrow-select').select2();


    var $bookId = 0;
    var $row;
    var $modal = $('#borrow-modal');
    var $select = $('#borrow-select');
    $("#footable-3").on("click", "tbody tr td button.borrowbtn", function () {
        $row = $(this).closest("tr");   // Finds the closest row <tr> 
        $bookId = $row.find(".bookId")     // Gets a descendent with class="nr"
            .text();         // Retrieves the text within <td>
        $modal.modal('show');
        $select.empty().trigger('change');
        getAllBorrowers($select);
    });



    $("#footable-3").on("click", "tbody tr td button.returnbtn", function () {

    });

    $modal.on("click", "div form div.modal-footer button[type='submit']", function (e) {
        e.preventDefault();
        var values = {
            bookId: $bookId,
            borrowerId: $select.val()
        };
        $.ajax({
            type: "POST",
            url: 'BorrowBook/Add',
            data: JSON.stringify(values),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                debugger 
                if (response.Success === true) {
                    var r = $row.find(".availableNumber").text();
                    var number = parseInt(r);
                    if (number > 0) {
                        $row.find(".availableNumber").html(parseInt(r) - 1);

                        $("#borrow-modal").modal('hide');
                    }
                } else {
                    debugger
                    alert(response.responseText);
                }
            },
            error: function (response) {
                alert("Error while inserting data");
            }
        });

        
        
    });
});

//Add Book
var addBook = function (values) {
    $.ajax({
        type: "POST",
        url: 'Home/Add',
        data: JSON.stringify(values),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function () {
            alert("Data has been added successfully.");
        },
        error: function () {
            alert("Error while inserting data");
        }
    });
}


//get all borrowers
function getAllBorrowers($select) {
    $.ajax({
        type: "Get",
        url: 'Borrower/GetAll',
        dataType: 'json',
        success: function (result) {
            $.each(result, function (key, obj) {
                var newOption = new Option(obj.Name, obj.Id, false, false);
                $select.append(newOption).trigger('change');
            });
        },
        error: function () {
            alert("Error while inserting data");
        }
    });
}

//Add Borrow book
function addBorrowBook(values) {
    
}
