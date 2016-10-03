# encoding: utf-8

# L'utilisateur entre p
p = int(input('Entrez un grand nombre premier p : '))

# L'utilisateur entre q
q = int(input('Entrez un grand nombre premier q : '))

# On calcule n 
n = p*q

print ("\nn = ",n,)

# On calcul phi(n)
phiden = (p-1)*(q-1)

print ("\nphi de n = ",phiden,)

# Variables de la boucle
compteur = 0
PGCD1 = 0

# Notre e qui s'incrémentera
e = 0

# Tant que PGCD de e et phi(n) différents de 1
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
    PGCD1 = pgcd(e,phiden)

# La fonction PGCD avec ses 2 arguments a et b
def pgcd(a,b):
    # L'algo PGCD
    while a != b:
        if a > b:
            a = a - b
        else:
            b = b - a
    return a;

# On affiche notre clé publique
print ("\nCle publique (",e,",",n,")")

# On demande d'entrer le texte à chiffrer
mot = raw_input('\nEntrez le mot ou la phrase à chiffrer : ')

# On récupère le nombre de caractères du texte.
taille_du_mot = len(mot)

i=0

# Tant que i inférieur au nombre de caractères
while i < taille_du_mot :
    # Comme i s'incrémente jusqu'à égalité avec la taille du mot, à chaque passage dans la fonction chaque lettre sera convertie.
        ascii = ord(mot[i])

