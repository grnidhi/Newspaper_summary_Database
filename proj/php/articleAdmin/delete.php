<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Oswald:wght@300;500&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="./styles/global.css">
    <style>
        .main-delete{
            height:80vh;
            display:flex;
            justify-content: center;
            align-items:center;
        }
        .main-delete input{
            border:var(--primary-dark) 2px solid;
        }
        .delete-form-container{
            height:200px;
            width:20%;
            border:var(--primary-dark) 2px solid;
            padding:20px;
            display:flex;
            flex-direction:column;
            justify-content:space-between;
            align-items:left;
        }
        .delete-form-container label{
            display:block;
        }
        .delete-form-container button{
            padding: 5px;
            margin-bottom: 10px;
            border: var(--primary-dark) 1px solid;
            background-color: var(--primary-main);
            font-family: 'Roboto', sans-serif;
        }
        .delete-form-container button:hover{
            background-color: var(--primary-dark);
            color: var(--primary-main);
            cursor: pointer;
        }
    </style>
    <title>Delete Article</title>
</head>
<body>
<?php include("./components/header.php")
    ?>
    <section class="main-delete">
        <form class="delete-form-container" id="article-check" action="./../postDeleteArticle.php" method="POST" onsubmit="return handleSubmit()">
            <div>
                <label for="">Enter the id to be deleted</label>
                <input type="text" required id="delete-id" name="aid">
            </div>
            <div >
                <button type="submit" name="submit">Delete</button>
            </div>
        </form>
    </section>
<?php include("./components/footer.php")
    ?>
    <script>
        function handleSubmit(){
            const formData = new FormData(document.getElementById('article-check'));
            let status=false;
            if(formData.get("aid")==""||formData.get('aid').length>3){
                    alert("invalid jid value");
                    return false;
                }
                else{
                    
                }
    
        }
    </script>
</body>
</html>