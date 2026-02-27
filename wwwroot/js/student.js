// student.js
document.addEventListener("DOMContentLoaded", function () {
    const table = document.getElementById("studentTable");

    // Add click listener for edit buttons
    table.addEventListener("click", function (e) {
        if (e.target.classList.contains("edit-btn")) {
            const row = e.target.closest("tr");
            const cells = row.querySelectorAll("td");

            const name = cells[1].innerText;
            const studentNumber = cells[2].innerText;
            const course = cells[3].innerText;
            const age = cells[4].innerText;

            // Prompt for new values
            const newName = prompt("Edit Name:", name);
            const newStudentNumber = prompt("Edit Student Number:", studentNumber);
            const newCourse = prompt("Edit Course:", course);
            const newAge = prompt("Edit Age:", age);

            if (newName && newStudentNumber && newCourse && newAge) {
                cells[1].innerText = newName;
                cells[2].innerText = newStudentNumber;
                cells[3].innerText = newCourse;
                cells[4].innerText = newAge;

                // Optional: call backend via AJAX to save changes
                const studentId = cells[0].innerText;

                fetch("/Student/EditStudent", {
                    method: "POST",
                    headers: { "Content-Type": "application/json" },
                    body: JSON.stringify({
                        Id: studentId,
                        Name: newName,
                        StudentNumber: newStudentNumber,
                        Course: newCourse,
                        Age: newAge
                    })
                });
            }
        }
    });
});