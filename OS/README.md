# Побитни команди и по нешто за grep, sed, awk на едно место 😙

## `tr`
Користи се за замена или бришење на карактери.
Пример: Претворање мали букви во големи:
```bash
Copy
Edit
echo "hello world" | tr 'a-z' 'A-Z'
# Излез: HELLO WORLD
```
## `sort`
Сортира линии во текстуален фајл или излез.
Пример:
```bash
Copy
Edit
echo -e "banana\napple\ncherry" | sort
# Излез:
# apple
# banana
# cherry
```
## `uniq`
Отстранува дупликати од сортиран текст.
Пример:
```bash
Copy
Edit
echo -e "apple\napple\nbanana\nbanana\ncherry" | uniq
# Излез:
# apple
# banana
# cherry
```
Важно: uniq работи само ако редовите се последователно исти, па затоа најчесто се комбинира со sort:
```bash
Copy
Edit
sort file.txt | uniq
```
## `cut`
Избира одредени колони или делови од редови.
Пример: Извлекување на вториот збор (разделен со :):
```bash
Copy
Edit
echo "user:password:1234" | cut -d':' -f2
# Излез: password
```
## `head`
Прикажува првите неколку редови од фајл или излез.
Пример:
```bash
Copy
Edit
head -n 5 /etc/passwd
# Ги прикажува првите 5 редови од фајлот
```
## `tail`
Прикажува последните неколку редови.
Пример:
```bash
Copy
Edit
tail -n 5 /var/log/syslog
# Ги прикажува последните 5 редови од лог фајлот
```
## `nl`
Ги додава броевите на секој ред.
Пример:
```bash
Copy
Edit
echo -e "apple\nbanana\ncherry" | nl
Излез:
     1  apple
     2  banana
     3  cherry
```

## grep `grep "pattern" file.txt` - Пребарување на текст во датотеки
grep итерира ред по ред, не збор по збор.

-> Ако треба само да најдеш ред што содржи збор

```bash
^ почеток на ред (starts with)
$ крај на ред (ends with)
. било кој знак (ignore n знаци)
* 0 или било колку појавувања на претходниот знак
[a-b] било кој знак шо е лексички меѓу a и b
```
#### Опции

```bash
-c → Броење на појавувања #(grep -c "error" file.txt)
-i → Игнорира големи/мали букви #(grep -i "test" file.txt)
-r → Рекурзивно пребарување низ фолдери #(grep -r "error" /var/logs/)
-n → Прикажува број на линија #(grep -n "error" file.txt)
-v → Инверзно пребарување #(ги дава редовите кои го немаат "pattern")
-o → Ги прикажува само совпаѓањата, не целиот ред #(grep -o "[0-9]\+" file.txt)
-w → Пребарува цели зборови	grep -w "error" log.txt
-E → Користи регуларни изрази (исто како egrep) #(grep -E "error|failed" file.txt)
-A N → Прикажува N редови после совпаѓањето	#grep -A2 "error" log.txt
-B N → Прикажува N редови пред совпаѓањето	#grep -B3 "error" log.txt
-C N → Прикажува N редови пред и после	#grep -C2 "error" log.txt
```

#### Примери

```bash
grep "233..." indeksi.txt #(сите шо индексот им почвит на 233)
grep " 20 " indeksi.txt #(сите пример шо имет 20 години)

ls -l | grep ^.rw #(само тие со read и write за user шо се)

I
grep "Ana" test.txt #(сите кај шо имат Ana)
grep -v "Ana" test.txt #(сите кај шо немат Ana)

II
cat test.txt | grep "Ana"
```

## sed `sed'/......./'` - Манипулација со текст (пронајди и замени)
sed па во единечни наводници пишиме / па pattern-от па / и `p` или `d`

-> Ако треба едноставна замена на текст во датотека

```bash
^ почеток на ред (starts with)
$ крај на ред (ends with)
. било кој знак (ignore n знаци)
* 0 или било колку појавувања на претходниот знак
[a-b] било кој знак шо е лексички меѓу a и b

sed '/.txt/'p  #(оние што имет .txt, т.е. шо го исполнвет pattern-от ги дават ДУПЛО.)
               #За да ги дајт само еднаш пишиме -n

sed -n '/.txt/'p #(Ќе ги дајт истите тие само по еднаш)

p е кратенка од print (работит со -n)
Ги дават дупло тие шо го исполнвет условот. За да ги дајт еднаш -n

d е кратенка од delete, ко тие шо не го исполнвет условот да не ги дават
Ги дават сите освен оние шо НЕ го исполнвет условот. (работит без -n !!!)
```

#### Опции
```bash
s/old/new/g → Го заменува првото појавување на "old" со "new"
s/old/new/g → Ги заменува сите појавувања
-i → Менува и ги зачувува промените во самата датотека #(sed -i 's/error/fixed/g' file.txt)
/pattern/d → Ги брише редовите што го содржат "pattern"
-n '/pattern/p' → Прикажува само редови што се совпаѓаат со шаблонот
d → Брише редови #(sed '/DELETE/d' file.txt)
-e → Изврши повеќе наредби #(sed -e 's/A/B/' -e 's/C/D/' file.txt)
```

#### Примери

```bash
sed '/s/pattern1/pattern2' #(замена на првото појавување на pattern1 со pattern2)
sed 's/old/new/' file.txt  #(Замени прво појавување на "old" со "new")

sed '/s/pattern1/pattern2/gi' #(g за сите појавувања, i за ignore case)

echo "hello world" | sed 's/world/Ana/'  #(hello Ana)
```

## awk `awk'{}'` - Напредна анализа на податоци (разделување на колони)
awk по default прајт split по празно место.
Првата колона мојме да ја пристапиме со $1, втората со $2 итн.
Последната колона ја пристапвиме со $NF

Внатре во awk мојт да се пишет обични if, for...

-> Ако треба да анализираш колони и филтрираш податоци

```bash
awk -F\, #(split по запирка)
awk -F\: #(split по две точки) мојме кој сакаме знак

awk '{print $1,$2,$3}' #(печатит прва, втора, трета колона одделени со празно место)

```

#### Опции
```bash
-F":" → Користи : како delimiter (awk -F":" '{print $1}' /etc/passwd)
NR → Број на редови (awk 'NR==3' file.txt → Прикажи го 3-тиот ред)
NF → Број на колони (awk '{print $NF}' file.txt → Последната колона)
if → Условно филтрирање (awk '$2 > 50 {print}' file.txt)
$N > X → Филтрира редови каде N-тата колона е поголема од X
{print $N} → Прикажи ја N-тата колона	awk '{print $2}' file.txt
BEGIN {} → Извршува команди пред обработка	awk 'BEGIN {print "Header"} {print $1}' file.txt
END {} → Извршува команди по обработка	awk '{sum+=$2} END {print sum}' file.txt
```

#### Филтрирање со regular expressions `~` `!~`
```bash
#Го печати целиот ред ако втората колона содржи "error"
awk '$2 ~ /error/ {print $0}' log.txt

#Го печати целиот ред ако втората колона НЕ содржи "error"
awk '$2 !~ /error/ {print $0}' log.txt

#Ги прикажува само редовите каде што првата колона започнува со голема буква
awk '$1 ~ /^[A-Z]/ {print $0}' file.txt
```

#### Филтрирање со бројки `==` `!=` `>` `<` `>=` `<=`
```bash
#Ги печати првата и третата колона само ако третата колона е поголема од 50
awk '$3 > 50 {print $1, $3}' data.txt

#Го печати целиот ред ако третата колона е точно 100
awk '$3 == 100 {print $0}' data.txt

#Ги печати сите редови каде што втората колона НЕ е "admin"
awk '$2 != "admin" {print $0}' users.txt
```

#### Филтрирање со стрингови `==` `!=` 
```bash
#Ги прикажува само редовите каде што втората колона е "root"
awk '$2 == "root" {print $0}' /etc/passwd

#Ги прикажува сите редови освен тие каде што првата колона е "user1"
awk '$1 != "user1" {print $0}' users.txt
```

#### Комбинирање на повеќе услови `&&` `||` 
```bash
#Ги печати редовите каде што втората колона е > 50 И третата колона содржи "error"
awk '$2 > 50 && $3 ~ /error/ {print $0}' log.txt

#Ги печати редовите каде што првата колона е "Alice" ИЛИ втората колона е помала од 10
awk '$1 == "Alice" || $2 < 10 {print $0}' data.txt
```

#### Минимум максимум
```bash
awk 'NR == 1 {min = max = $1} 
     $1 < min {min = $1} 
     $1 > max {max = $1} 
     END {print "Min:", min, "Max:", max}' numbers.txt
```

#### Збир и производ
prod *= $1 ќе даде грешка ако prod не е иницијализирано. 
```bash
awk 'BEGIN {prod = 1} {sum += $1; prod *= $1} 
     END {print "Sum:", sum, "Product:", prod}' numbers.txt
```

#### Просек
```bash
awk '{sum += $1; count++} 
     END {if (count > 0) print "Average:", sum / count}' numbers.txt
```

#### Ранг (разлика меѓу максимум и минимум)
```bash
awk 'NR == 1 {min = max = $1} 
     $1 < min {min = $1} 
     $1 > max {max = $1} 
     END {print "Range:", max - min}' numbers.txt
```

#### Преврти редови (оддолу нагоре)
```bash
awk '{lines[NR] = $0} 
     END {for (i=NR; i>0; i--) print lines[i]}' text.txt
```

#### Преврти колони (оддесно налево)
```bash
awk '{for (i=NF; i>0; i--) printf "%s ", $i; print ""}' text.txt
```

#### Примери
```bash
#1.Најди датотеки со големина поголема од 100MB
ls -lh | awk '$5 ~ /M/ && $5+0 > 100 {print $0}'

#2.Извлечи IP адреси што не се од "192.168."
awk '$1 !~ /^192\.168\./ {print $1}' access.log

#3.Преброј ги сите редови што содржат „ERROR“ во log.txt
awk '/ERROR/ {count++} END {print "Errors found:", count}' log.txt

#4.Прикажи го најдолгиот ред во датотека
awk '{if (length > max) { max = length; line = $0 }} END {print line}' file.txt
```











