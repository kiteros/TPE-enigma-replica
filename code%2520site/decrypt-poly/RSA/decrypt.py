from tkinter import *
from math import *
#Fonction
def Calcn():
    global n
    p1=int(p.get())
    q1=int(q.get())
    n=p1*q1
    chaine.configure(text='n='+str(n))
def CalcPhiden():
    global phiden
    p1=int(p.get())
    q1=int(q.get())
    phiden=(p1-1)*(q1-1)
    chaine1.configure(text='phi de n='+str(phiden))
def Calced():
    r=0
    global e
    e=0
    i=1
    p1=int(p.get())
    q1=int(q.get())
    while r==0:
        if((p1<e)and(q1<e)and(e<phiden)and(e/i!=phiden/i)):
            r=1
        i=i+1
        e=e+1
        
    global d
    d=0
    compteur = 0
    while compteur == 0:
        if((e * d % phiden == 1)and(p < d)and(q < d)and(d < phiden)):
            compteur = 1
        d = d + 1
    d = d - 1


    chaine2.configure(text='Clé privée=('+str(d)+','+str(n)+')')
def motdecrypt():
    lettre_decrypt = ""
    lettre_crypt = 0
    lettre_crypt = int(block.get())
    ascii = lettre_crypt**d%n
    lettre_decrypt = chr(ascii)
    lettre.insert(0, lettre_decrypt)
fen1 = Tk()
fen1.title('RSA')
#Zones d'entrées
p = Entry(fen1)
q = Entry(fen1)
block = Entry(fen1)
lettre = Entry(fen1)
#Affichage des Consignes
pt= Label(fen1, text='Entrez p')
qt= Label(fen1, text='Entrez q')
bt= Label(fen1, text='Entrez un block a decrypté')
#Texte
chaine= Label()
chaine1= Label()
chaine2= Label()
#Bouton
b1= Button(text='Calculez n', command=Calcn)
b2= Button(text='Calculez phi de n', command=CalcPhiden)
b3= Button(text='Déterminer la Clé privé', command=Calced)
b4= Button(text='Décrypter', command=motdecrypt)
#Placement des boutons
b1.grid(row =2)
b2.grid(row =3)
b3.grid(row =4)
b4.grid(row =6)
#Placement du texte
chaine.grid(row =2, column =1)
chaine1.grid(row =3, column =1)
chaine2.grid(row =4, column =1)
lettre.grid(row =6, column =1)
#Placement des Consignes
qt.grid(row =0)
pt.grid(row =1)
bt.grid(row =5)
#Placement des zones d'entrées
p.grid(row =0, column =1)
q.grid(row =1, column=1)
block.grid(row =5, column=1)
fen1.mainloop()
