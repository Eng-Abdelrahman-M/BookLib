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
                allowDelete:false,
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
        ajaxFunction(values);
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
    var $modal = $('#borrow-modal');
    $(".borrow-editing").bind("click", function (evt) {
        debugger
        alert('Button Clicked');
        $modal.modal('show');
        evt.preventDefault();
    });
    $("#returnbtn").on('click', function (e) {
        debugger
        alert("Error while inserting data");
    });
});
var ajaxFunction = function (values) {
    $.ajax({
        type: "POST",
        url: 'Home/Add',
        data: JSON.stringify(values),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function () {
            alert("Data has been added successfully.");  
        },
        error: function() {
            alert("Error while inserting data");
        }
    });
}


function getAllBorrowers() {
    $.ajax({
        type: "Get",
        url: 'Borrower/GetAll',
        success: function (result) {
            return result;
            alert("Data has been added successfully.");
        },
        error: function () {
            alert("Error while inserting data");
        }
    });
}