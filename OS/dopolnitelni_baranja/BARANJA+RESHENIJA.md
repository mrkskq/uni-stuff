*1. Да се пресметаат просечните цени на лаптопите според Intel процесорите (i3,i5,i7,i9) и да се испечатат во растечки редослед (https://courses.finki.ukim.mk/pluginfile.php/275408/mod_resource/content/1/laptops.csv)*

```bash
$ cat laptops.csv | awk -F\, '{print $4 " " $NF}' | grep "Intel" | awk '{split($3,proc,"-"); p=proc[1]; procesori[p]+=$4; brojaci[p]+=1;}END{for(p in procesori){print p ": " procesori[p]/brojaci[p]}}' | sort -k2


$ cat laptops.csv | awk -F\, '$4~/^Intel/ {print}' | awk -F\, '{if(match($4, /(i[3579])/, c)){core=c[1]; sum[core]+=$NF; counter[core]+=1;}}END{for(core in sum){print core ": " sum[core]/counter[core]}}' | sort -n -k 2
```

*2. Да се креира фајл со име, презиме, оддел на вработување, година на вработување и плата за вработени во една компанија;
(како оддели да се наведат IT, Sales, HR, Marketing и Finance)
да се испечати просечната плата на вработените кои работат во Sales или Finance*

```bash
$ cat employees.csv | awk -F\, 'NR>1{if($3=="Sales" || $3=="Finance"){total+=$NF; counter+=1;}}END{print total/counter}'
```

*3. Да се креира фајл со индекс, датум, време(минути:часови), група(GroupA/GroupB) и прикачено(submitted/not_submitted),
да се испечатат индексот и времето сортирано според времето, времето треба да се претвори во секунди(пр. 12:36 --> 756),
пришто треба да се земат само оние индекси кои завршуваат на 1 или 2*

```bash
$ cat groupAB.csv | awk -F\, 'NR>1 {print $1 " " $3}' | grep "^.....[1-2]" | awk '{split($2,time,":"); vreminja[$1]=time[1]*60+time[2]}END{for(i in vreminja){print i " " vreminja[i]}}' | sort -n -k 2
```

*4. [Модификација на задача 3] За секоја група посебно, најди ги студентите на кои им требало најмногу време да го прикачат резултатот (од оние кои успешно го прикачиле резултатот).*

```bash
$ cat groupAB.csv | awk -F\, 'NR>1{split($3,t,":"); time=t[1]*60+t[2]; if($4=="GroupA" && $NF=="submitted"){if(time>maxA || !maxA){maxA=time; idA=$1}}else if($4=="GroupB" && $NF=="submitted"){if(time>maxB || !maxB){maxB=time; idB=$1}}}END{print "GroupA: " idA "\nGroupB: " idB}'
```

*5. Да се сумираат цените на лаптопите според производител на графичка картичка (Nvidia, AMD) со една команда (https://courses.finki.ukim.mk/pluginfile.php/275408/mod_resource/content/1/laptops.csv)*

```bash
$ cat laptops.csv | awk -F\, '{if($5~/Nvidia/){sumN+=$NF}else if($5~/AMD/){sumA+=$NF}}END{print "Nvidia: " sumN "\nAMD: " sumA}'
```

*6. Да се прикажи лекот со највисока цена кој е издаден по 2010 година (https://courses.finki.ukim.mk/mod/page/view.php?id=159695)*

```bash
$ cat drugs.csv | awk -F\, 'NR>1{if($3>2010){if($NF>max || !max){max=$NF}}}END{print max}'
```

*7. Да се креира фајл со податоци за потрошувачка на електрична енергија (колони household, city, kWh, month) и да се најде најголемиот потрошувач, а потоа и просечната потрошувачка по месец
(решениево е ак се пратит месец ко аргумент на скриптата, за него да се најт просечна потрошувачка:)*

```bash
#!/bin/bash

cat electricity_usage.csv | awk -F\, 'NR>1{if($3>max || !max){max=$3; maxP=$1}}END{print "Najgolem potroshuvach: " maxP}'

if [ $# -eq 1 ]
then
        month=$1
        # echo "$month"
        cat electricity_usage.csv | grep "$month" | awk -F\, '{
                sum+=$3; count+=1;
        }
        END{
                if(count==0){print "There is not any data for this month in this file."}
                else{print "Prosechna potroshuvachka za mesec "$NF": " sum/count}
        }'
else
        echo "Enter one month for testing"
fi
```

*8. Да се пресмета просечно време на изнајмување на луксузните возила за месец мај (rental_sys.txt) / calculate the average rental time for the luxury cars that were rented out in May (rental_sys.txt)*

```bash
$ cat rental_sys.txt | grep "2024-05-.." | awk '{if($3=="Luxury"){sum+=$NF; count+=1;}}END{print sum/count}'
```

*9. Да се креира фајл со податоци за полагање на предмети (индекс, предмет, поени и оценка) и да се испечати просечната оцена на студентите кои положиле ОС и се запишани во 2023та година*

```bash
$ cat exam_results.csv | grep ^23 | awk -F\, '{if($2=="OS" && $NF>5){sum+=$NF; count+=1;}}END{print sum/count}'
```











