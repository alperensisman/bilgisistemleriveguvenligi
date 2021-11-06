<?php
	header("Content-type:image/png");
	$a = substr(strval(rand(0,999999)), -6);
	$b = substr(strval(rand(0,999999)), -6);
	$c = substr(strval(rand(0,999999)), -6);
	$sifre = substr(md5(strval($a) + strval($b) + strval($c)),-6);
 $width = 150;
 $height = 50;
 $resim = ImageCreate($width, $height);
 $beyaz = ImageColorAllocate($resim, 255, 255, 255);
 $sari = ImageColorAllocate($resim, 255, 255, 0);
 $kirmizi = ImageColorAllocate($resim, 139, 0, 0);
 $siyah = ImageColorAllocate($resim, 0, 0, 0);
 ImageFill($resim, 0, 0, $siyah);
 ImageString($resim, 10, 50, 16, $sifre, $beyaz);
 ImageLine($resim, 500, 4, 0, 29, $sari);
 ImageLine($resim, 500, 159, 0, 0, $kirmizi);
 $save = "engine/Images/captchaimage.png";
 ImagePng($resim, $save);
 imagedestroy($resim);
 echo $sifre;
?>
