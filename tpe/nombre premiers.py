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
 
listep=[2,3]
newlistep=[]
n_a_tester=5
print ("\n*** PREM'S V 1.0 ***\n")
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
print()
print ("Écriture terminée, fin du programme (pour voir la liste complète des NP, tapez 'listep', puis valider)\n")
