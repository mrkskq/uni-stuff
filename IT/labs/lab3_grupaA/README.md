Ko ke se kreirat proektot odberi MVC i tamu desno gore kaj Authentication odberi Individual Accounts (za da se izgenerirat nekoja baza na pocetok za polesno)

Na pochetok Build na proektot

So sekoja izmena (ili na pogolema izmena nakraj) vo Tools -> NuGet Packege Manager -> Package Manager Console 

> Enable-Migrations (samo na pocetok)

> Add-Migration (i nekoe ime na migracijata (pr. Initial, blabla....)) <br>
> Update-Database <br>

Prvo napishi gi tie trite vo Models <br>
Posle dodaj gi trite Controllers (avtomatski so tretiot controller sve ke se izgenerirat to so Entity Framework i odberi za koj model i vo Data context class: ApplicationDbContext) <br>
Vo controlerot za Doctor imat izmena nakraj <br>

i posle vo Views imat nekoj izmeni vo nekoja linija (od to sho avtomatski ke se izgeneriret preku kontrolerite) - obelezani se so komentari <br> //-----------> <br>

i uste izmena vo to Layout za preku link da mojt da se pristapit 😙
