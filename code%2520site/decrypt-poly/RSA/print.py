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
def Calce():
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
    chaine2.configure(text='Clé publique=('+str(e)+','+str(n)+')')
def motcrypt():
    mot1=str(mot.get())
    taille=len(mot1)
    i=0
    crypter = " "
    while i<taille:
        ascii = ord(mot1[i])
        lettre_crypt = ascii**e%n
        crypter = crypter + str(lettre_crypt) + " "
        i = i + 1
    block.insert(0, str(crypter))
fen1 = Tk()
fen1.title('RSA')
#Zones d'entrées
p = Entry(fen1)
q = Entry(fen1)
mot = Entry(fen1)
block = Entry(fen1)
#Affichage des Consignes
pt= Label(fen1, text='Entrez p')
qt= Label(fen1, text='Entrez q')
mt= Label(fen1, text='Entrez le mot a crypte')
#Texte
chaine= Label()
chaine1= Label()
chaine2= Label()
#Bouton
b1= Button(text='Calculez n', command=Calcn)
b2= Button(text='Calculez phi de n', command=CalcPhiden)
b3= Button(text='Déterminer la Clé publique', command=Calce)
b4= Button(text='Crypter', command=motcrypt)
#Placement des boutons
b1.grid(row =2)
b2.grid(row =3)
b3.grid(row =4)
b4.grid(row =6)
#Placement du texte
chaine.grid(row =2, column =1)
chaine1.grid(row =3, column =1)
chaine2.grid(row =4, column =1)
block.grid(row =6, column =1)
#Placement des Consignes
qt.grid(row =0)
pt.grid(row =1)
mt.grid(row =5)
#Placement des zones d'entrées
p.grid(row =0, column =1)
q.grid(row =1, column=1)
mot.grid(row =5, column=1)
fen1.mainloop()
