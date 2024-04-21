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

fetch('http://localhost:5148/Project/Developers')
  .then(response => {
    if (!response.ok) {
      throw new Error('Hiba a válaszban');
    }
    return response.json();
  })
  .then(developers => {
    console.log('Fejlesztők:', developers);

    const developerSelect = document.getElementById('developer');
    developerSelect.innerHTML = '';
    developers.forEach(developer => {
      const option = document.createElement('option');
      option.value = developer.developerId;
      option.textContent = developer.name;
      developerSelect.appendChild(option);
    });

    $('#taskForm').submit(function(event) {
        event.preventDefault();
        var taskName = $('#taskName').val();
        var taskDescription = $('#taskDescription').val();
        var developerId = $('#developer').val();
        if (taskName.trim() !== '' && taskDescription.trim() !== '' && developerId.trim() !== '') {
            addTaskToEndpoint(taskName, taskDescription, developerId);
        }
    });
  })
  .catch(error => {
    console.error('Hiba történt a fejlesztők lekérdezése közben:', error);
  });

  function addTaskToEndpoint(taskName, taskDescription, developerId) {
    var taskName = $('#taskName').val();
    var taskDescription = $('#taskDescription').val();
    var developerId = $('#developer').val();
    const apiUrl = 'http://localhost:5148';
    const endpoint = `${apiUrl}/Project/${developerId}/task`;

    const data = {
        taskId: 0,
        name: taskName,
        description: taskDescription,
        projectId: 1,
        userId: 1,
        deadLine: new Date().toISOString() 
    };

    fetch(endpoint, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    })
    .then(response => {
        if (!response.ok) {
            throw new Error(console.log(data));
        }
        console.log(console.log(data));
    })
    .catch(error => {
        console.error('Hiba:', error);
    });
}
