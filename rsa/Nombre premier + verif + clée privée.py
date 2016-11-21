import time
from math import sqrt
 
#J'utilise psycho pour plus de rapidité
if __name__ == '__main__':
    # Import Psyco if available
    try:
        import psyco
        psyco.full()
    except ImportError:
        pass
besoin1 = 0
besoin1=int(input('Voulez vous calculer les nombres premiers ?(1 pour oui, 0 pour non) :'))

if besoin1 == 1:
     
    listep=[2,3]
    newlistep=[]
    n_a_tester=5
    print ("\nNombres premiers : \n")
    limite=int(input("Calculer jusqu'à : "))
    print()
    a=3
     
    def test (n_a_tester):
        n_list=len(listep)
        for i in range(n_a_tester):
     
            if n_a_tester%listep[i]==0:
                break
            elif (i+1)==n_list or n_a_tester<listep[i]**2:
                listep.append(n_a_tester)
                return n_a_tester
            elif n_a_tester%listep[i]!=0:
                i+=1
     
    start=time.ctime()
    while a<limite :
        test (n_a_tester)
        n_a_tester+=1
        a+=1
    finish=time.ctime()
    debut=(int(start[11]+start[12])*3600)+(int((start[14]+start[15]))*60)+int(start[17]+start[18])
    fin=(int(finish[11]+finish[12])*3600)+(int((finish[14]+finish[15]))*60)+int(finish[17]+finish[18])
    temps=fin-debut

    for i in range(5):
        newlistep.append(listep[len(listep)-i-1])
    newlistep.reverse()
    # On écrit les nombres P
    nombre_prems=len(listep)
    nombre_prems=str(nombre_prems)
    print("\nTemps du calcul : environ",temps,"sec")
    print("\nNombre de NP trouvés :", nombre_prems)
    print('\nVoici les 5 derniers :\n')
    for i in range(5):
        print('-',newlistep[i])

    print('\nAppuyer sur entrée pour continuer')

    input()

print('\n\n\n\n')


besoin2 = 0

besoin2=int(input('Voulez vous verifier les deux nombres premiers, et afficher la clée privée ?(1 pour oui, 0 pour non) :'))

if besoin2 == 1 :
    #ecriture du programme de verification des 2 nombre premier

    print('\n\nLe programme va verifier si les 2 nombres premiers choisis sont utilisable pour le programme de chiffrement RSA.')

    reessayer = 1
    while reessayer == 1:
        p=int(input('\nEntrez le premier nombre premier : '))
        q=int(input('\nEntrez le second nombre premier : '))

        #verification de la compatibilité

        def pgcd(a,b):
            # L'algo PGCD
            while a != b:
                if a > b:
                    a = a - b
                else:
                    b = b - a
            return a;
        phiden = (p-1)*(q-1)
        n=p*q
        #variable de la boucle
        compteur=0
        PGCD1=0
        e=0
         

        while PGCD1 != 1 :
            # Tant que compteur=0
            while compteur == 0 :   
                # Si p inférieur à e et si q inférieur à e et si e inférieur à n
                if((p < e)and(q < e)and(e < phiden)) :
                    # La boucle se coupe (on peut aussi mettre le mot-clé : break
                    compteur = 1     
                # Tant que rien n'est trouvé, e s'incrémente
                e = e + 1
            # On récupère le résultat du pgcd   
            PGCD1 = pgcd(e,n)

        compteur = 0 
        d=0

        while compteur == 0:
            # Les conditions vu ci-dessus :
                        
            if((e * d % phiden == 1)and(p < d)and(q < d)and(d < phiden)):
                compteur = 1
            d = d + 1

            if d>10000000:
                print('\nLes nombres premiers "p" et "q" ne sont pas compatible')
                compteur = 1
        if d<10000000:
            print('\nLes nombre premiers "p" et "q" sont compatible')
            compteur = 1
            reessayer = 0
        if d>10000000:
            reessayer=int(input('Voulez vous réessayer ? (1 pour oui, 0 pour non)'))
            compteur = 1

    d-=1
    



    # affichage de la cléé privéé
    if d<10000000:
        print('\nclée privée = ( ',d,',',n,')')

if besoin1 == 1:
    print ("pour voir la liste complète des NP, tapez 'listep', puis valider\n")

input()
