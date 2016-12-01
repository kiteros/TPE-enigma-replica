from tkinter import *
from time import *

fermer=[]

fenetre=Tk()
fenetre.geometry("1080x720")

def close():
    for i in range(len(fermer)):
        fermer[i].destroy()

def menuPrems():
    close()
    titre=Label(fenetre, text='Programme RSA')
    titre.pack(pady=7)
    calcul=Button(fenetre, text='Calculer')
    verif=Button(fenetre, text='Verifier deux nombres premiers pour RSA')
    cle=Button(fenetre, text='Clée publique et privée')
    retour=Button(fenetre, text='Retour')
    calcul.pack(pady=5)
    verif.pack(pady=5)
    cle.pack(pady=5)
    retour.pack(pady=5)
    fermer=[titre, calcul, verif, cle, retour]

def acceuil():

    close()
    entre.destroy()
    nbprems=Button(fenetre, text='Nombres premiers',command=menuPrems)
    nbprems.pack(pady=5)
    chiffrementRsa=Button(fenetre, text='Chiffrement RSA', command=close)
    chiffrementRsa.pack(pady=5)
    dechiffrementRsa=Button(fenetre, text='Déchiffrement RSA', command=close)
    dechiffrementRsa.pack(pady=5)
    fermer=[titre, nbprems, chiffrementRsa, dechiffrementRsa]


titre=Label(fenetre, text='Programme RSA')
titre.pack(pady=7)
entre=Button(fenetre, text='Commencer',command=acceuil)
entre.pack(pady=5)

fenetre.mainloop
