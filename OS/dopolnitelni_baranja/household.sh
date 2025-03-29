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
