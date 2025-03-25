<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <!-- sets the default base url of the page -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Oswald:wght@300;500&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="./styles/global.css">
    <style>
        .main-title{
            text-align:center;
            margin-top:40px;
        }
        #main-body{
            display:flex;
            justify-content:center;
            align-items:center;
            height:80vh;
        }
        .operation-list{
            display:flex;
            gap:30px;
        }
        .operation-list a{
            text-decoration:none;
            color:var(--primary-dark);
        }
        .operation-list h4{
            text-align:center;
        }
        .operation-item{
            width:150px;
            height:150px;
            background-position:center;
            background-size:60%;
            background-repeat:no-repeat;
            transition:all 0.1s ease-out;
            border:solid 2px var(--primary-dark);
            padding:20px;
        }
        .operation-item:hover{
            background-size:75%;
        }
        .operation-list a{
            text-decoration:none;
        }
        .item-1{
            background-image:url("http://localhost/proj/assets/edit.png");
        }
        .item-2{
            background-image:url("http://localhost/proj/assets/delete.png");
        }
        .item-3{
            background-image:url("http://localhost/proj/assets/changes.png");
        }
        .item-4{
            background-image:url("http://localhost/proj/assets/cells.png");
        }

    </style>
    <title>Article-Admin</title>
</head>
<body>
    <?php include("./components/header.php")
    ?>


    <h2 class="main-title">
        Welcome to Article Admin
    </h2>
    <section id="main-body">
        <div class="operation-list">
           <a href="./create.php"> <div class="operation-item item-1"></div><h4>Create</h4> </a>
           <a href="./delete.php"> <div class="operation-item item-2"></div><h4>Delete</h4> </a>
           <a href="./update.php"> <div class="operation-item item-3"></div><h4>Update</h4> </a>
           <a href="./display.php"> <div class="operation-item item-4"></div><h4>Display</h4> </a>
        </div>
    </section>


    <?php include("./components/footer.php")
    ?>
</body>
</html>