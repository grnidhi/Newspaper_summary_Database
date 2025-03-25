<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Editor Table</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            text-align: center;
        }

        table {
            width: 80%;
            margin: 20px auto; /* Center the table on the page */
            border-collapse: collapse;
        }

        table, th, td {
            border: 1px solid #ddd;
        }

        th, td {
            padding: 12px;
            text-align: left;
        }

        th {
            background-color: #f2f2f2;
        }
    </style>
</head>
<body>

<?php

// Database connection parameters
$host = "localhost"; // replace with your database host
$username = "root"; // replace with your database username
$password = ""; // empty password
$database = "bugle-crunch"; // replace with your database name

// Create a database connection
$conn = new mysqli($host, $username, $password, $database);

// Check the connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

// SQL query to retrieve data from the "editor" table
$sql = "SELECT eid, name, date, phone, exp, domain FROM editor";
$result = $conn->query($sql);

// Check if the query was successful
if ($result) {
    // Display the data in a table
    echo "<table>
            <tr>
                <th>EID</th>
                <th>Name</th>
                <th>Date</th>
                <th>Phone</th>
                <th>Exp</th>
                <th>Domain</th>
            </tr>";

    // Fetch and display each row of the result set
    while ($row = $result->fetch_assoc()) {
        echo "<tr>
                <td>" . $row['eid'] . "</td>
                <td>" . $row['name'] . "</td>
                <td>" . $row['date'] . "</td>
                <td>" . $row['phone'] . "</td>
                <td>" . $row['exp'] . "</td>
                <td>" . $row['domain'] . "</td>
            </tr>";
    }

    echo "</table>";

    // Free the result set
    $result->free();
} else {
    echo "Error: " . $sql . "<br>" . $conn->error;
}

// Close the database connection
$conn->close();

?>

</body>
</html>
