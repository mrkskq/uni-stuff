## Step by step решена задачата за вакцини: 😙

> Download VaccinationApp -> Extract </br>
> Во Visual Studio отвори го VaccinationApp.sln </br>
> Напрај прво Build на проектот

Досреди ги моделите пред да напрајш миграција. Додај ги тие со vitual и напиши ја точка 3. </br> Плус стави [Key] над Id во трите модели.

После ова напрај миграција </br>
> Tools -> NuGet Package Manager -> Package Manager Console </br>
> Enable-Migrations </br>
> Add-Migration Initial </br>
> Update-Database </br>

Оди во Solution Explorer -> Show All Files -> Во App_Data требит да ја имаш базата, во Tables мојш да ги видиш табелите за секој модел.

За секој модел додај Controller од тој третиот со Entity Framework. </br>
Model class: (моделот) </br>
Data context class: ApplicationDbContext

<hr>

## 1. 
a) смени во Index кај Patients и во Details кај Patients. </br>
b) смени во Index кај VaccinationCenters 
(ископирај од тие ActionLink шо се долу и само смени да е за името) </br>
c) смени во Index кај VaccinationCenters 
горе додај <th> таг шо викат Број на вакцинирани пациенти, а долу кај <td> стави count од листата со вакцини шо ја имат тој вакцинален центар.

## 2.
Bo Views -> Shared -> _Layout смени ги линкојте да бидат Пациенти и Вакцинални центри

## 4. 
- смени во Details кај VaccinationCenters </br>
- ископирај од тие ActionLink шо се долу и само смени да е за "Додади вакциниран пациент"  </br>
- Bo VaccinationCenters controller-от додај акција АddPatient (над Edit ми е додаена зш е слична функцијата со таја) и GET и POST </br>
- За таја акција додај View шо ќе е Empty without model </br>
- Оди во Create кај Vaccines и ископирај ја html формата и стави ја во новото View за AddPatient </br>
- Најгоре додај само @model VaccinationApp.Models.Vaccine </br>
- Накрај во Details напрај листа од сите вакцинирани пациенти шо ќе се прикажвет за тој вакцинален центар.


## 5.
- ископирај ја скриптата за jQuery DataTable и стави ја најдолу во Index кај Patients. </br>
- Стави `<thead> <tbody>` тагој на табелата со пациенти, и стави id на табелата. Истото id стај го и во скриптата долу. </br> 
- Под тие трите ActionLink стави button за Delete и стај му класа `js-delete`. И стај му `data-patient-id` со вредноста на Id-то на пациентот. Смени соодветно и во скриптата долу.  </br>
- Оди во PatientsController, ископирај го то шо е во DeleteConfirmed акцијата и додај го во Delete акцијата. </br>
- И во скрпитата смени  </br>
url: "/Patients/Delete/" + button.attr("data-patient-id"),

## 6. 
- Solution Explorer -> Отвори ја базата -> Отвори ја табелата AspNetRoles -> рачно додај ги улогите шо требет (User, Doctor) </br>
- Models -> ManageViewModels -> ископирај од друг проект делот за public class RoleUser  </br>
- Controllers -> AccountController -> ископирај од друг проект делот за public ActionResult AddRoleToUser() и HttpPost за public ActionResult AddRoleToUser() </br>
- Views -> Account -> напрај View za AddRoleToUser (ископирај од друг проект) </br>
- За делот со авторизација: </br>
Solution Explorer -> АppStart -> FilterConfig -> додај filters.Add(new AuthorizeAttribute()); </br>

<hr>

Оди регистрирај ги двата мејлој на апликацијата. </br>
После оди во Views -> AddRoleToUser -> стегни Run -> и додај улога на мејлот соодветно.

(Ненајавен корисник има пристап само до Index акцијата од Home контролерот.) -> Кај HomeController над Index стави [AllowAnonymous] -> ова се пишит за аку сакаме до таја акција да имат пристап некој шо не е најавен, мојт да го глеат Index без да е потребна најава.

Кај PatientsController и кај VaccinationCentersController додај најгоре [Authorize], a над секоја акција освен над Index, додај [Authorize(Roles = "Doctor")]
















