$(document).ready(function() {
    $('#taskForm').submit(function(event) {
        event.preventDefault();
        var taskName = $('#taskName').val();
        var taskDescription = $('#taskDescription').val();
        var developer = $('#developer').val();
        if (taskName.trim() !== '' && taskDescription.trim() !== '' && developer.trim() !== '') {
            var listItem = $('<li>').addClass('list-group-item');
            var taskInfo = $('<div>').html('<strong>Feladat neve:</strong> ' + taskName + '<br><strong>Leírás:</strong> ' + taskDescription + '<br><strong>Fejlesztő:</strong> ' + developer);
            var editBtn = $('<button>').addClass('btn btn-info btn-sm float-right mx-1 editTask').html('<i class="fas fa-edit"></i>').data('taskName', taskName).data('taskDescription', taskDescription).data('developer', developer);
            var deleteBtn = $('<button>').addClass('btn btn-danger btn-sm float-right mx-1 deleteTask').html('<i class="fas fa-trash"></i>');
            listItem.append(taskInfo).append(editBtn).append(deleteBtn);
            $('#taskList').append(listItem);
            $('#taskName').val('');
            $('#taskDescription').val('');
            $('#developer').val('');
        }
    });

    $(document).on('click', '.deleteTask', function() {
        $(this).closest('li').remove();
    });

    $(document).on('click', '.editTask', function() {
        var listItem = $(this).closest('li');
        var taskName = $(this).data('taskName');
        var taskDescription = $(this).data('taskDescription');
        var developer = $(this).data('developer');
        var editForm = $('<form>').addClass('editForm');
        var nameField = $('<input>').addClass('form-control editInput').val(taskName);
        var descriptionField = $('<textarea>').addClass('form-control editInput').val(taskDescription);
        var developerField = $('<input>').addClass('form-control editInput').val(developer);
        var saveBtn = $('<button>').addClass('btn btn-success btn-sm saveTask').html('<i class="fas fa-save"></i>');
        editForm.append('<div class="form-group"><label>Feladat neve</label></div>').append(nameField)
                .append('<div class="form-group"><label>Leírás</label></div>').append(descriptionField)
                .append('<div class="form-group"><label>Fejlesztő</label></div>').append(developerField)
                .append(saveBtn);
        listItem.html(editForm);
    });

    $(document).on('click', '.saveTask', function() {
        var editedTaskName = $(this).siblings('.editForm').find('.editInput').eq(0).val();
        var editedTaskDescription = $(this).siblings('.editForm').find('.editInput').eq(1).val();
        var editedDeveloper = $(this).siblings('.editForm').find('.editInput').eq(2).val();
        var listItem = $(this).closest('li');
        var taskInfo = $('<div>').html('<strong>Feladat neve:</strong> ' + editedTaskName + '<br><strong>Leírás:</strong> ' + editedTaskDescription + '<br><strong>Fejlesztő:</strong> ' + editedDeveloper);
        var editBtn = $('<button>').addClass('btn btn-info btn-sm float-right mx-1 editTask').html('<i class="fas fa-edit"></i>').data('taskName', editedTaskName).data('taskDescription', editedTaskDescription).data('developer', editedDeveloper);
        var deleteBtn = $('<button>').addClass('btn btn-danger btn-sm float-right mx-1 deleteTask').html('<i class="fas fa-trash"></i>');
        listItem.html(taskInfo).append(editBtn).append(deleteBtn);
    });
});
