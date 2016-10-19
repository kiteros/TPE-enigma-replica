alpha = "abcdefghijklmnopqrstuvwxyz"
a = input("message a coder")
b = input("entrer la cle")


if not b.isalpha():
    print("ntm")
else:
    a = a.lower()
    b = b.lower()
    a.replace(" ", "")
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
for t in range(len(messageToCode)):
        compteur %= len(listeDecalage)
        lettre1 = alpha.index(messageToCode[i])
        lettre2 = alpha.index(messageToCode[compteur])
        lettre = alpha[(lettre1 + lettre2)%26]
        messageDecoded += lettre
        compteur+=1
