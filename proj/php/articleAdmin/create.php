<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Oswald:wght@300;500&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="./styles/global.css">
    <link rel="stylesheet" href="http://localhost/proj/styles/styles3.css">
    <title>Create Article</title>
</head>
<body>
    <?php include("./components/header.php")
    ?>
            <section class="article-form-main" >
            <div class="aritcle-form-container">
                <div class="wrapper-forms" id="wrapper-forms">
                    <div class="article-form">
                        <h2 class="article-form-header">
                            Identify the Journalist
                        </h2>
                        <form class="article-form" id="article-check">
                            <label for="jid">Enter Journalist ID</label>
                            <input type="text" name="jid" id="jid"><br>
                        </form>
                        <button onclick="handleCheckJid()">check</button>
                    </div>

                    <div class="article-form">
                        <h2 class="article-form-header">
                            Enter Article details
                        </h2>
                        <form action="./../postCreateArticle.php" method="post" class="article-form" id="article-main" enctype="multipart/form-data" onsubmit="return handleSubmit()">
                            <label for="title">Enter Title</label>
                            <input type="text" name="title" id="article-title" autocomplete="additional-name" required >

                            <label for="desc">Enter Description</label>
                            <textarea name="desc"  cols="30" rows="10" required id="article-desc"></textarea>

                            <label for="category">Choose a category</label>
                            <select name="category" required id="article-category">
                                <option value="movie" selected>Movie</option>
                                <option value="sports">Sports</option>
                                <option value="technology">Technology</option>
                                <option value="education">Education</option>
                                <option value="politics">Politics</option>
                                <option value="entertainment">Entertainment</option>
                                <option value="other">Other</option>
                            </select>

                            <label for="photo">Upload Photo</label>
                            <input type="file" name="photo" max="1" id="article-photo" required>
                            <input type="text" name="jid-post" id="jid-post" style="display: none;"><br>
                            <button type="submit" name="submit">Send</button>
                        </form>
                    </div>

                </div>
            </div>
        </section>

<?php include("./components/footer.php")
    ?>
     <script>
            let jid = "";

            function handleCheckJid(){
                const formData = new FormData(document.getElementById('article-check'));

                
                if(formData.get("jid")==""||formData.get('jid').length>3){
                    alert("invalid jid value");
                }
                else{
                    fetch("./../utility/postCheckJid.php",{
                    method:"POST",
                    body:formData
                    }).then(res=>{
                        return res.json();
                    }).then(res=>{
                        if(res.code==0){
                            alert("message :"+res.message);

                        }else{
                            document.getElementById('wrapper-forms').setAttribute('class',"wrapper-forms slide-right");
                            jid = document.getElementById('jid').value;
                        }
                    })
                }


            }
            
            function handleSubmit(){
                const formData = document.getElementById('article-main');
                const title = document.getElementById('article-title').value;
                const desc = document.getElementById('article-desc').value;
                const category = document.getElementById('article-category').value;
                const jidPost = document.getElementById('jid-post');

                if(title.length==0 || title.length>50){
                    alert("Invalid title please enter again");
                    return false;
                }
                if(desc.length<3 || desc.length>1000){
                    console.log(desc.length);
                    alert("Invalid description");
                    return false;
                }

                jidPost.value=jid;

                return true;
                
            }

        </script>
</body>
</html>