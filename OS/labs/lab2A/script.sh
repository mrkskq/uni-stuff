#!/bin/bash

if [ $# -ne 1 ]
then
        echo "USAGE: script.sh <FILE>"
        exit 1
fi

data=$1

echo "Exam Scores Anaysis"
echo "-------------------"

num=`awk 'NR>1 {count++;}END{print count}' $data`

echo "Total Number of Students: $num"
echo " "
echo "Subject Averages:"

awk -F\, -v n=$num 'NR>1 {M+=$3;S+=$4;E+=$5;H+=$6;}
END{
printf "  Math:     %.2f\n", M/n;
printf "  Science:  %.2f\n", S/n;
printf "  English:  %.2f\n", E/n;
printf "  History:  %.2f\n", H/n;
}' $data

echo " "
echo "Subject Extreme Performers:"

tmpMax=3 #pocetna kolona
tmpMin=3 #pocetna kolona

#Funkcija sho go naogjat najdobar i najlos student (prvo poeni+ime, posle oddelno ime i poeni)
func() {
max=`cat $data | awk -F\, 'NR>1 {print $"'$tmpMax'"","$2}' | sort -n -r | head -n 1`
min=`cat $data | awk -F\, 'NR>1 {print $"'$tmpMin'"","$2}' | sort -n | head -n 1`

hscore=`echo $max | cut -d',' -f1`
hname=`echo $max | cut -d',' -f2`

lscore=`echo $min | cut -d',' -f1`
lname=`echo $min | cut -d',' -f2`

echo "  $1 - Highest: $hname (Score: $hscore), Lowest: $lname (Score: $lscore)"

tmpMax=`expr $tmpMax + 1`
tmpMin=`expr $tmpMin + 1`
}


for subject in Math Science English History
do
        func $subject
done
