<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Online shop</title>

    <style>
        h1{
            display: flex;
            justify-content: center;
        }
        div{
            margin: 10px;
        }
        label, input, select{
            display: inline-block;
            width: 300px;
        }
        th, td{
            border: 1px solid black;
        }
        #tabeli{
            display: flex;
            justify-content: space-evenly;
        }
        #tabeli div{

        }
        table{
            display: inline-block;
            margin-right: 50px;
            border-collapse: collapse;
        }
        .yellow{
            background-color: yellow;
        }
    </style>
</head>
<body>

<h1>Online shop</h1>
<div>
    <label for="name">Name and surname</label><input type="text" id="name">
</div>
<div>
    <label for="item">Item</label><input type="text" id="item">
</div>
<div>
    <label for="code">Item code</label><input type="text" id="code">
</div>
<div>
    <label for="description">Item description</label><input type="text" id="description">
</div>
<div>
    <label for="price">Price</label><input type="number" id="price">
</div>
<div>
    <label for="use">Used</label><select id="use"><option>used</option><option>never-used</option></select>
</div>

<button onclick="add()">Add</button>

<p>Active items: <span id="active-items">0</span></p>

<div id="tabeli">
    <div>
        <h2>Unused items</h2>
        <table id="never-used">
            <tr>
                <th>Name</th><th>Item</th><th>Price</th><th>Code</th><th>Number</th><th>Actions</th>
            </tr>
        </table>
    </div>

    <div>
        <h2>Used items</h2>
        <table id="used">
            <tr>
                <th>Name</th><th>Item</th><th>Price</th><th>Code</th><th>Number</th><th>Actions</th>
            </tr>
        </table>
    </div>
</div>



<script>
    var active_items = 0
    function add(){
        var name = document.getElementById("name")
        name = name.value
        var item = document.getElementById("item")
        item = item.value
        var code = document.getElementById("code")
        code = code.value

        //kataloshki broj
        var katalonski = code
        katalonski = katalonski.replaceAll("!", "")
        for (var i = 0; i < 10; i++){
            katalonski = katalonski.replaceAll(i, "")
        }
        //console.log(katalonski)


        var description = document.getElementById("description")
        description = description.value
        var price = document.getElementById("price")
        price = price.value
        var use = document.getElementById("use")
        use = use.value

        // console.log(name)
        // console.log(item)
        // console.log(code)
        // console.log(description)
        // console.log(price)
        // console.log(use)

        if (name.length==0 || item.length==0 || code.length==0 || description.length==0 || price.length==0 || use.length==0){
            alert("Ne se vneseni site polinja")
            return
        }

        var proverka = document.getElementById(code)
        //console.log(proverka)
        if (proverka != null){
            alert("Predmetot ne mozhe da se dodade")
            return;
        }

        if (price <= 0){
            alert("Cenata e <= 0! Vnesete cena!")
            return;
        }

        active_items += 1;
        how_many_are_active()

        var tabela = document.getElementById(use)
        var redica = "<tr><td>"+name+"</td><td>"+item+"</td><td>"+price+"</td><td>"+code+"</td><td>"+katalonski+"</td><td><button onclick='sold(this)'>Sold</button><button onclick='update(this)'>Update</button></td></tr>"
        tabela.innerHTML += redica

    }

    function how_many_are_active(){
        var active_ekran = document.getElementById("active-items")
        active_ekran.innerHTML = active_items
    }
    function sold(obj){
        var redica = obj.parentNode.parentNode
        redica.className = "yellow"
        var kopce = obj
        kopce.parentNode.removeChild(kopce)
        active_items -= 1;
        how_many_are_active()

    }

    function update(obj) {
        var redica = obj.parentNode.parentNode
        var kelii = redica.getElementsByTagName("td")
        kelii[kelii.length-1].innerHTML = "<button onclick='sold(this)'>Sold</button><button onclick='save(this)'>Save</button>"
        for (var i=0; i<(kelii.length-1); i++){
            kelii[i].innerHTML = "<input type='text' value='"+kelii[i].innerHTML+"'>"
        }
    }

    function save(obj){
        var redica = obj.parentNode.parentNode
        var kelii = redica.getElementsByTagName("td")
        kelii[kelii.length-1].innerHTML = "<button onclick='sold(this)'>Sold</button><button onclick='update(this)'>Update</button>"
        for (var i=0; i<(kelii.length-1); i++){
            var vrednost = kelii[i].getElementsByTagName("input")[0].value
            kelii[i].innerHTML = vrednost
        }
    }
</script>


</body>
</html>
