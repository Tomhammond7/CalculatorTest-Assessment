document.addEventListener('DOMContentLoaded', function () {
    var modalContainer = document.getElementById('exampleModal');

    // Get the controls for modifying styles
    var backgroundColorInput = document.getElementById('backgroundColorInput');
    var backgroundColorInput1 = document.getElementById('backgroundColorInput1');
    var backgroundColorInput2 = document.getElementById('backgroundColorInput2');
    var fontSizeInput = document.getElementById('fontSizeInput');

    // Get the Apply Styles button
    var applyStylesButton = document.getElementById('applyStylesButton');

    // Apply styles when the Apply Styles button is clicked
    applyStylesButton.addEventListener('click', function () {
        // Get the selected values from the controls
        var selectedBackgroundColor = backgroundColorInput.value;
        var selectedFontSize = fontSizeInput.value + 'px';
        var modalHeader = document.querySelector('.modal-header');
        var modalTitle = document.querySelector('.modal-title');
        var closeBtn = document.getElementById('close');

        // Apply the selected styles to the modal container
        modalHeader.style.backgroundColor = selectedBackgroundColor;
        modalTitle.style.color = backgroundColorInput1.value;
        modalContainer.style.fontSize = selectedFontSize;
        closeBtn.style.backgroundColor = backgroundColorInput2.value;
    });

    var calculatorForm = document.getElementById('calculatorForm');
    calculatorForm.addEventListener('submit', function (event) {
        event.preventDefault();

    var form = event.target;
    var button = event.submitter;
    var action = button.getAttribute('data-action');

    var formData = new FormData(form);

    fetch(action, {
        method: 'POST',
    body: formData
            })
                .then(response => response.text())
                .then(data => {
        document.getElementById('result').textContent = "Result = " + data;
                })
                .catch(error => {
        console.error('Error:', error);
    document.getElementById('result').textContent = 'Error occurred.';
        });
    });
});
