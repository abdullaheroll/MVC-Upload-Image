        /*
		   TR:
		   WebImage ve FileInfo kütüphaneleri eklenir.
		   Veri tabanı bilgileri eklenir.
		   
		   EN:
		   WebImage and FileInfo libraries are added.
           Database content.
		*/
		
		//TR: View kısmı için [HttpGet] ActionResult tanımlanır.
		//EN: [HttpGet] ActionResult is defined for View part.
	[HttpGet]
        public ActionResult UplaodImage()
        {
            return View();
        }
        
		//TR: Veriyi post etmek için [HttpPost] olarak ActionResult tanımlanır.
		//EN: An ActionResult is defined as [HttpPost] to post the data.
        [HttpPost]
        public ActionResult UplaodImage(Students s , HttpPostedFileBase Image)
        {
			//TR: Students s; Veri tabanından işlem yapacağımız tablo.
			//EN: An ActionResult is defined as [HttpPost] to post the data.
			
		    //TR: HttpPostedFileBase Image; Görsel Yüklememizi sağlaycak Sınıf.
			//EN: HttpPostedFileBase Image; The Class that will enable us to Load an Image.
            WebImage img = new WebImage(Image.InputStream); //TR: Eklemek istediğimiz görsel için giriş kısmı. //EN: The introductory part for the image we want to add.
            FileInfo imginfo = new FileInfo(Image.FileName);//TR: Yüklemek istediğimiz görselin dosya bilgisi. //EN: The file information of the image we want to upload.
            string teamsimgname = Guid.NewGuid().ToString() + imginfo.Extension; //TR: Yüklediğimiz görselin yeniden adlandırma kısmı. //EN: The renaming part of the image we uploaded.
            img.Resize(212, 271);//TR: Yüklediğimiz görseli yeniden boyutlandırma. //EN: Resizing the image we uploaded.
            img.Save("~/Image/" + teamsimgname);//TR: Görselin kayıt edileceği dizin. //EN: The directory where the image will be saved.
            s.Image = "/Image/" + teamsimgname;//TR: Görselin veri tabanında kayıt edileceği yol. s; Tablomuzdan gelen Image kolonu. //EN: The path to save the image in the database. NS; Image column from our table.
            db.Students.Add(s); //TR: Veri tabanına ekleme kısmı. //EN: Adding to the database.
            db.SaveChanges();  //TR: Veri tabanına kayıt edlilen kısım. //EN: The part recorded in the database.
		}
