from tkinter import *

fenetre=Tk()
fenetre.geometry("1080x720")

nbprems=Button(fenetre, text='Nombres premiers')
nbprems.pack()
chiffrementRsa=Button(fenetre, text='Chiffrement RSA')
chiffrementRsa.pack()
dechiffrementRsa=Button(fenetre, text='Déchiffrement RSA')
dechiffrementRsa.pack()

fenetre.mainloop()
