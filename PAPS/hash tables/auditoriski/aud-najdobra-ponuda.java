/*
На еден светски познат предавач секојдневно му пристигнуваат понуди да држи предавања. 
За секоја понуда се дадени датуми, време на почеток, градот и износот на хонорарот за предавањето (во долари). 
Ваша задача е за даден датум да го прикажете предавањето кое би му донело најголема заработка на предавачот. 
Доколку нема понуди за дадениот датум да се испечати „No offers”.
Влез: Во првиот ред од влезот е даден бројот на понуди, а во секој нареден ред се дадени: датумот и времето на предавањето (формат dd/mm/yyyyhh:mm), 
градот во кој ќе се одржува предавањето и износот на хонорарот. Во последниот ред е даден датумот за кој треба да испечатите која понуда е најдобра за тој датум.
Излез: Деталите на понудата за тој датум

Пример
Влез:
7
27/01/2016 14:00 NewYork 6000
28/01/2016 08:00 Paris 3000
28/01/2016 14:00 Munich 5000
27/01/2016 09:00 Beijing 8000
27/01/2016 08:00 Seattle 4000
28/01/2016 09:00 SaltLakeCity 10000
28/01/2016 09:00 Lagos 12000
27/01/2016

Излез:
09:00 Beijing 8000
*/

import java.util.*;

class MapEntry<K extends Comparable<K>, E> {
    // Each MapEntry object is a pair consisting of a key (a Comparable object)
    // and a value (an arbitrary object).
    K key;
    E value;

    public MapEntry(K key, E val) {
        this.key = key;
        this.value = val;
    }

    public String toString() {
        return "<" + key + "," + value + ">";
    }
}

class SLLNode<E> {
    protected E element;
    protected SLLNode<E> succ;

    public SLLNode(E elem, SLLNode<E> succ) {
        this.element = elem;
        this.succ = succ;
    }

    @Override
    public String toString() {
        return element.toString();
    }
}


class CBHT<K extends Comparable<K>, E> {

    // An object of class CBHT is a closed-bucket hash table, containing
    // entries of class MapEntry.
    private SLLNode<MapEntry<K, E>>[] buckets;

    @SuppressWarnings("unchecked")
    public CBHT(int m) {
        // Construct an empty CBHT with m buckets.
        buckets = (SLLNode<MapEntry<K, E>>[]) new SLLNode[m];
    }

    private int hash(K key) {
        // Translate key to an index of the array buckets.
        return Math.abs(key.hashCode()) % buckets.length;
    }

    public SLLNode<MapEntry<K, E>> search(K targetKey) {
        // Find which if any node of this CBHT contains an entry whose key is equal to targetKey.
        // Return a link to that node (or null if there is none).
        int b = hash(targetKey);
        SLLNode<MapEntry<K, E>> currNode = buckets[b];
        while (currNode != null) {
            MapEntry<K, E> currEntry = currNode.element;
            if (currEntry.key.equals(targetKey)) return currNode;
            else currNode = currNode.succ;
        }
        return null;
    }

    public void insert(K key, E val) {
        // Insert the entry <key, val> into this CBHT.
        // If entry with same key exists, overwrite it.
        MapEntry<K, E> newEntry = new MapEntry<>(key, val);
        int b = hash(key);
        SLLNode<MapEntry<K, E>> currNode = buckets[b];
        while (currNode != null) {
            MapEntry<K, E> currEntry = currNode.element;
            if (currEntry.key.equals(key)) {
                // Make newEntry replace the existing entry ...
                currNode.element = newEntry;
                return;
            } else currNode = currNode.succ;
        }
        // Insert newEntry at the front of the SLL in bucket b ...
        buckets[b] = new SLLNode<>(newEntry, buckets[b]);
    }

    public void delete(K key) {
        // Delete the entry (if any) whose key is equal to key from this CBHT.
        int b = hash(key);
        SLLNode<MapEntry<K, E>> predNode = null, currNode = buckets[b];
        while (currNode != null) {
            MapEntry<K, E> currEntry = currNode.element;
            if (currEntry.key.equals(key)) {
                if (predNode == null) buckets[b] = currNode.succ;
                else predNode.succ = currNode.succ;
                return;
            } else {
                predNode = currNode;
                currNode = currNode.succ;
            }
        }
    }

    public String toString() {
        String temp = "";
        for (int i = 0; i < buckets.length; i++) {
            temp += i + ":";
            SLLNode<MapEntry<K, E>> curr = buckets[i];
            while (curr != null) {
                temp += curr.element.toString() + " ";
                curr = curr.succ;
            }
            temp += "\n";
        }
        return temp;
    }
}

class Offer{
    String time;
    String city;
    int price;

    public Offer(String time, String city, int price) {
        this.time = time;
        this.city = city;
        this.price = price;
    }

    @Override
    public String toString() {
        return time + " " + city + " " +  price;
    }
}

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = sc.nextInt();
        sc.nextLine();

        CBHT<String, Offer> table = new CBHT<>(2*n-1); //key e datumot, value e ponudata
        for (int i = 0; i < n; i++) {
            String date = sc.next();
            String time = sc.next();
            String city = sc.next();
            int price = sc.nextInt();
            sc.nextLine();

            Offer offer = new Offer(time, city, price);
            SLLNode<MapEntry<String, Offer>> curr = table.search(date);
            if (curr == null){
                table.insert(date, offer);
            }
            else{
                int prev_price = curr.element.value.price;
                Offer prev_offer = curr.element.value;

                if (prev_price >= price){
                    table.insert(date, prev_offer);
                }
                else{ // if price > prev_price
                    table.insert(date, offer); //novata ponuda
                }
            }
        }

        String d = sc.nextLine();
        SLLNode<MapEntry<String, Offer>> curr = table.search((d));
        if (curr == null){
            System.out.println("No offers");
        }
        else{
            System.out.println(curr.element.value);
        }
    }
}
