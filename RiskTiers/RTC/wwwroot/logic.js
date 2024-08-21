document.addEventListener('DOMContentLoaded', function () {
    const checkboxes = document.querySelectorAll('input[type="checkbox"]');

    // Listen for changes on any checkbox
    checkboxes.forEach(checkbox => {
        checkbox.addEventListener('change', function () {
            checkConditionsAndChangeColor();
        });
    });

    function checkConditionsAndChangeColor() {
        // Get all rows in the table
        const rows = document.querySelectorAll('tbody tr');

        rows.forEach(row => {
            // Define variables for each column in the row
            const dataLeavingJHM = row.querySelector('input[name*="DataLeavingJHM"]:checked') !== null;
            const phiLDS = row.querySelector('input[name*="PHILDS"]:checked') !== null;
            const phi = row.querySelector('input[name*="PHI"]:checked') !== null;
            const pii = row.querySelector('input[name*="PII"]:checked') !== null;
            const consent = row.querySelector('input[name*="Consent"]:checked') !== null;
            const lds = row.querySelector('input[name*="LDS"]:checked') !== null;
            const phiButNoPII = row.querySelector('input[name*="PHIButNoPII"]:checked') !== null;
            const personNoPHIPII = row.querySelector('input[name*="NoPHIPII"]:checked') !== null;
            const aggregate = row.querySelector('input[name*="Aggregate"]:checked') !== null;

            Console.WriteLine("testing for each" + pii);
            // Implement your specific condition logic here
            let turnRed = false;

            // Example condition based on provided logic:
            if (dataLeavingJHM && (phiLDS || phi || pii || consent)) {
                turnRed = true;
            }

            // Apply color change based on condition
            if (turnRed) {
                row.style.backgroundColor = 'red';
            } else {
                row.style.backgroundColor = ''; // Reset to default
            }
        });
    }

    // Initial run to apply the logic on page load
    checkConditionsAndChangeColor();
});
