alpha = "abcdefghijklmnopqrstuvwxyz"

choix = int(input("1 pour coder, 2 pour decoder"))

if choix==1:

    a = input("message a coder")
    b = input("entrer la cle")
    a = ''.join(a.split())

    if not b.isalpha() or not a.isalpha():
        print("que des lettres")

    else:
        a = a.lower()
        b = b.lower()
        compteur = 0
        message = ""
        for i in range(len(a)):
            compteur %= len(b)
            lettre1 = alpha.index(a[i])
            lettre2 = alpha.index(b[compteur])
            lettre = alpha[(lettre1 + lettre2)%26]
            message += lettre
            compteur+=1
    
        print(message)


elif choix==2:

    a = input("message a decoder")
    b = input("entrer la cle")
    a = ''.join(a.split())
    

    if not b.isalpha() or not a.isalpha():
        print("que des lettres")

    else:
        a = a.lower()
        b = b.lower()
        compteur = 0
        message = ""
        for i in range(len(a)):
            compteur %= len(b)
            lettre1 = alpha.index(a[i])
            lettre2 = alpha.index(b[compteur])
            lettre = alpha[(lettre1 - lettre2)%26]
            message += lettre
            compteur+=1
    
        print(message)