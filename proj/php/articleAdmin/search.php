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
        .main-container{
            padding-inline:40px;
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
        .search{
            padding: 5px;
            border-top:var(--primary-dark) 1px solid;   
            border-bottom:var(--primary-dark) 1px solid;   
            margin:5px;
        }
        .search-container{
            display: flex;
            justify-content: flex-end;
            align-items: center;
            gap: 10px;
        }
        .search-container input{
            border: none;
            border: var(--primary-dark) 1px solid;
            background-color: var(--primary-main);
            font-family: 'Roboto', sans-serif;

        }
        .search-container label{
            font-weight: 100;
            color: var(--secondary-dark);
            font-family: 'Roboto', sans-serif;
        }
        .search-container a{
            text-decoration: none;
            color: var(--secondary-dark);
            font-family: 'Roboto', sans-serif;
        }
        .search-container a:hover{
            color: var(--primary-accent);
        }


        /* based on filter */
        .filter-list{
            display:flex;
            list-style: none;
            gap: 10px;
        }
        .filter-item{
            padding: 2px;
            padding-inline: 5px;
            border: var(--primary-dark) 1px solid;
        }
        .filter-item:hover{
            background-color: var(--primary-dark);
            color: var(--primary-main);
            cursor: pointer;
        }
        .filter-item-selected{
            background-color: var(--primary-dark);
            color: var(--primary-main);
        }


        .main-display{
            padding-top:100px;
            padding-bottom:200px;
            display:flex;
            justify-content:center;
        }
        table{
            width:80%;
        }
        table td{
            border:var(--primary-dark) 2px solid;
            text-align:center;
            height:100px;
            padding-inline:10px;

        }
        table th{
            border:var(--primary-dark) 2px solid;
            text-align:center;
            font-weight:800;
            padding-inline:20px;

        }
    </style>
    <title>Article-Admin</title>
</head>
<body>
    <?php include("./components/header.php")
    ?>
    <div class="main-container">    
        <section class="search">
            <div class="search-container">
                <input type="text" name="searchField" id="search-field" placeholder="search">
                <label for="searchField" id="search-btn">Search</label>
            </div>
        </section>
        <section class="search-filters">
            <div class="filter-list-container">
                <ul class="filter-list">
                    <li class="filter-item" id="category">
                        category
                    </li>
                    <li class="filter-item" id="title">
                        title
                    </li>
                    <li class="filter-item" id="description">
                        description
                    </li>
                </ul>
            </div>
        </section>
        <section id="main-body">
            <table>
            <tr>
                <th>Article ID</th>
                <th>Title</th>
                <th>Description</th>
                <th>Date</th>
                <th>Category</th>
                <th>Journalist Id</th>
                <th>Approved</th>
                <th>Editor Id</th>
                <th>PhotoURL</th>
            </tr>
            </table>
        </section>
    </div>

    <?php include("./components/footer.php")
    ?>
    <script>
         let filterSelection = "";
         let table= "";
         const searchField = document.getElementById("search-field");
         let searchBtn=document.getElementById('search-btn');
        //updates every 
        function updateUi(array){
            array.forEach(fun=>{
                fun();
            })
        }

        function updateSearchField(){
            searchField.setAttribute('placeholder',"search "+filterSelection);
        }

        const filterListItems = document.querySelectorAll(".filter-item");
        filterListItems.forEach(element => {
            element.addEventListener("click",(e)=>{
                filterListItems.forEach(item=>{
                    if(item.getAttribute('id')!=e.target.getAttribute('id')){
                        item.setAttribute('class',"filter-item");
                    }
                    else{
                        item.setAttribute('class',"filter-item filter-item-selected");
                        filterSelection=item.getAttribute('id');
                        updateUi([updateSearchField]);
                    }
                })

            })
        });

        searchBtn.addEventListener('click',(e)=>{
            console.log("click");
            if(filterSelection==""||searchField.value==""){
                alert("Enter something");
            }else{
                let formD = new FormData();
                formD.append("search-str",searchField.value);
                formD.append("category",filterSelection);
                fetch("./../utility/getArticle.php",{
                    method:"POST",
                    body:formD
                }).then((res)=>{
                    return res.json();
                }).then(res=>{
                    if(res.code==0){
                        alert("failure");
                    }else{
                        alert(res.body);
                    }
                })
            }
        })




    </script>
</body>
</html>