from tkinter import *

fenetre=Tk()
fenetre.geometry("1080x720")
titre=Label(fenetre, text='Programme RSA')
titre.pack(pady=7)
nbprems=Button(fenetre, text='Nombres premiers')
nbprems.pack(pady=5)
chiffrementRsa=Button(fenetre, text='Chiffrement RSA')
chiffrementRsa.pack(pady=5)
dechiffrementRsa=Button(fenetre, text='Déchiffrement RSA')
dechiffrementRsa.pack(pady=5)

fenetre.mainloop()
