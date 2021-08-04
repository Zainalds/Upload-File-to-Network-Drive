        public async Task<IActionResult> UploadTarget(IFormFile File, string targetType, int FinancialYear, string redirectUrl)
        {
            var UploadDocumentHelper = new UploadDocumentHepler();
            var UploadViewModel = new UploadViewModel();
            //var result = await UploadDocumentHelper.UploadRepTarget(File, targetType);
            var fileExt = System.IO.Path.GetExtension(File.FileName).ToLower();

            if (fileExt != ".csv")
            {
                UploadViewModel.FileErrorMessage = "Please upload a csv format file";
            }
            else
            {
                var pathAndFile = "\\\\tiger\\CreditNote\\";
                pathAndFile += File.FileName;                
                var path = "\\\\tiger\\CreditNote\\";
                if (System.IO.File.Exists(pathAndFile))
                {
                    System.IO.File.Delete(pathAndFile);
                }
                using (var fileStream = new FileStream(Path.Combine(path, File.FileName), FileMode.Create))
                {
                    await File.CopyToAsync(fileStream);
                }
            }
            UploadViewModel.url = redirectUrl;            
            UploadViewModel.FinancialYear = FinancialYear;
            return View(UploadViewModel);
        }
