import json
from base64 import b64encode,b64decode
from Crypto.Cipher import AES
from Crypto.Random import get_random_bytes


def encryption(data):
    key = "rnop3TnHwJ7P9zzLb0Z3qUjfhu1Cx9bW".encode('utf-8')
    cipher = AES.new(key, AES.MODE_CFB)
    ct_bytes = cipher.encrypt(data)
    iv = b64encode(cipher.iv).decode('utf-8')
    ct = b64encode(ct_bytes).decode('utf-8')
    result = json.dumps({'iv':iv, 'ciphertext':ct})
    print(result)



def decryption(json_input,mykey):
        b64 = json.loads(json_input)
        iv = b64decode(b64['iv']+b64['ciphertext'])[:16]
        value = b64decode(b64['iv']+b64['ciphertext'])[16:]
        cipher = AES.new(mykey, AES.MODE_CFB, iv=iv)
        return cipher.decrypt(value);






#                                                            p4psltayVQ7eTjVE
veriler=json.dumps({"iv": "YsiebTh0Sjr8dZKo", "ciphertext": "p4psltayVQ7eTjVEfXVhJh2KMl3BCeHj8eJz7OvWjpNVLbwsqDeIp492KHNqlD54w/FTTFLIYxb4ABTEZfCj3r7uT4PDWWZMjhQ="}) 
mykey="rnop3TnHwJ7P9zzLb0Z3qUjfhu1Cx9bW"

#veriler=json.dumps({"iv": "crGTopEfBGXE1k1x", "ciphertext": "40YLp07vJIuR0TfMaNByWwXdtsp5YFy56MU37H8="}) 
#mykey="wEgDCNvhccofPTkFt9zUdDgZDIVdGC9L"
cozumlu = decryption(veriler,mykey.encode('utf8'))cozulemeyen=b'3\x9d\x98<\x8d\xc5\xfbX\xfc{\xf3K'cozulemeyen2=b'\9d\98\8d\c5\fb\fc\f3'#XDlkXDk4XDhkXGM1DGIMYwwz#print(str(cozumlu));liste=[]for ch in cozulemeyen2: 
    liste.append(ch)for i in range(9999):
    sting=""
    for x in liste:
        sting+=chr(x^i)    if "grup uyelerinin" in sting:        print("bulundu")print("bitti")