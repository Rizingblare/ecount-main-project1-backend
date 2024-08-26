document.addEventListener('DOMContentLoaded', function () {
    const selectBtn = document.getElementById('selectBtn');
    let data = { Age: 27, Name: '재희' }
    selectBtn.addEventListener('click', function () {
        fetch('/study/select', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)

        })
            .then(response => response.json())
            .then(data => {
                if (data.isSuccess) {
                    alert('Success');
                }
                else {
                    alert('Fail');
                }
            })
            .catch(error => {
                console.error('error:', error);
                alert('An error occurred');
            })
    })
})