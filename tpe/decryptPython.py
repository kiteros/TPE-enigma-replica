import string

def getMaxOfList(listToMax):
    max_ = 0;
    for i in range(len(listToMax)):
        if(listToMax[i] > max_):
            max_ = listToMax[i]
    return max_

fichier=open('dico.txt','r')
listeMots = fichier.readlines()
fichier.close()
cle = 0
alphabet = list(string.ascii_lowercase)
messageAcrypter = input("Entrez le message à crypter : ")
listLettres = list(messageAcrypter)
nbMotsTotal = [0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0]
nbMotsFrancais = [0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0]
messageDecrypte = ["","","","","","","","","","","","","","","","","","","","","","","","","","",""]
for t in range(len(listeMots)):
    listeMots[t] = listeMots[t]

for cle in range(0, 26):
    messageDecrypte[cle] = "";
    for i in range(len(listLettres)):
        
        
        if(listLettres[i] == ' '):
            messageDecrypte[cle] += ' '
        else:
            positionLettre = alphabet.index(listLettres[i])
            nouvellePosition = (positionLettre + cle) % 26
            messageDecrypte[cle] += alphabet[nouvellePosition]
    #Spliter avec les espaces
    listeMots2 = messageDecrypte[cle].split(" ")
    nbMotsTotal[cle] = len(listeMots2)
    #tester si les mots sont dans le dico
    for x in range(len(listeMots2)):
        
        if(listeMots2[x] + "\n" in listeMots):
            nbMotsFrancais[cle] = nbMotsFrancais[cle] + 1
            
            
    print("message crypté : " + messageDecrypte[cle] + " cle : ",cle)
    print("nombre de mots : ",nbMotsTotal[cle])
    print("mots francais : ", nbMotsFrancais[cle])

plusDeMots = getMaxOfList(nbMotsFrancais)
cleTrouve = nbMotsFrancais.index(plusDeMots)
messageDecrypt2 = messageDecrypte[cleTrouve]
print("\nplus de mots frnacias ",plusDeMots)
print("le message décrypté est : ",messageDecrypt2)


