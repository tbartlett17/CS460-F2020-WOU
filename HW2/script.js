console.log("Javascript is being executed.....");

function login(event)
{
    event.preventDefault();

    var username = $('#username').val();
    var password = $('#password').val();
    
    if (username == 'tyler' && password == 'test')
    {
        
        console.log("Welcome " + username + "! You are logged in.");
        window.alert("Welcome " + username + "! You are logged in.");
        window.location.href = "musicPlayer.html";

    }
    else
    {
        console.log("failed to login - invalid credentials");
        window.alert("failed to login - invalid credentials");
    }   
}
$('#loginForm').submit(login);


function register(event)
{
    
    console.log("dont work");
    document.getElementById("demo").innerHTML = "Functionality not available at this time.";

}

function generatePlaylist()
{
    var files = "./music/*";
    
    for (var i = 0, f; f = files[i]; i++)
    {
        console.log(f,name);
    }
    
    
    var table = document.getElementById("playlist");
    var rowIndex = 1;
    var colIndex = 0;

    var row = table.insertRow(rowIndex);
    var cell1 = row.insertCell(colIndex);

    cell1.innerHTML = "test";


}

function handleFileSelect(evt) {
    var files = evt.target.files; // FileList object

    var table = document.getElementById("playlist");
    
    

    // files is a FileList of File objects. List some properties.
    var output = [];
    for (var i = 0, f; f = files[i]; i++)
    {
        //output.push('<li><strong>', escape(f.name), '</strong> (', f.type || 'n/a', ') - ');
        console.log(f.name);

        var row = table.insertRow(i+1);
        var cell1 = row.insertCell();
        var cell2 = row.insertCell();
        var cell3 = row.insertCell();
        //cell1.innerHTML = "<tr onclick='dequeue(this)'></tr>";
        //cell1.onclick = "dequeue(this)";
        cell2.innerHTML = f.name;

        var btn = document.createElement('button');
            btn.innerHTML = 'x';
            btn.setAttribute('onclick', 'dequeue(this.parentNode.parentNode)');
        cell3.appendChild(btn);

    }
    document.getElementById('list').innerHTML = '<ul>' + output.join('') + '</ul>';
  }

  document.getElementById('files').addEventListener('change', handleFileSelect, false);


  function dequeue(x)
  {
    //alert("Row index is: " + x.rowIndex);
    document.getElementById("playlist").deleteRow(x.rowIndex);
  }