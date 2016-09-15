#!/usr/bin/env python
# -*- coding: latin-1 -*-
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
n_a_tester=5
print ("\n*** PREM'S a0.10 ***\n")
limite=int(input("Calculer jusqu'à : "))
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
# On écrit les nombres P
nombre_prems=len(listep)
nombre_prems=str(nombre_prems)
print("temps du calcul : environ",temps,"sec")
print("nombre de NP trouvés :", nombre_prems)
print(str(listep))

print ("Écriture terminée, fin du programme \n")
