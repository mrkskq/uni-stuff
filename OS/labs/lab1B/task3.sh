#Напишете командна процедура која ќе прима еден влезен аргумент кој ќе претставува име на фајл. Потребно е процедурата да го пополни наведениот фајл со содржините на сите .txt фајлови во истиот директориум за кои корисникот има пермисии за читање (нема пермисии за запишување и извршување). Така што содржината помеѓу два фајла ќе биде одделена со нов ред.

#Потребно е да проверите дали е наведен влезен аргумент, доколку не е, испечатете Insert name of file!
#Доколку се наведени повеќе од еден влезен аргумент, испечатете Too many input arguments!
#Во сите други ситуации, зачувувајте ја содржината на исфилтрираните датотеки во наведениот фајл.

#пример bash script.sh total.txt

#!/bin/bash

IFS='\n'

if [ $# -eq 0 ]
then
        echo "Insert name of file!"
elif [ $# -gt 1 ]
then
        echo "Too many input arguments!"
else
        final_file=$1

        for file in *.txt
        do
                if [ -r "$file" ] && [ ! -w "$file" ] && [ ! -x "$file" ]
                then
                        cat "$file" >> "$final_file"
                        echo " " >> "$final_file"
                fi
        done
        echo "------------------------------------------------------------------------"
        echo "Posle dodavanje na sodrzinite, finalniot fajl ${final_file} izgleda vaka:"
        cat "$final_file"
fi
