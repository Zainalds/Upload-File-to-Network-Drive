public async Task<IActionResult> UploadTarget(IFormFile File, string targetType, int FinancialYear, string redirectUrl)
        {
            var UploadDocumentHelper = new UploadDocumentHepler();
            var UploadViewModel = new UploadViewModel();
            //var result = await UploadDocumentHelper.UploadRepTarget(File, targetType);
            var fileExt = System.IO.Path.GetExtension(File.FileName).ToLower();

            var pathAndFile = "\\\\tiger\\CreditNote\\";
            pathAndFile += File.FileName;
            if (fileExt != ".csv")
            {
                UploadViewModel.FileErrorMessage = "Please upload a csv format file";
            }
            else
            {
                if (System.IO.File.Exists(pathAndFile))
                {
                    System.IO.File.Delete(pathAndFile);
                }
                using (var localFile = System.IO.File.OpenWrite(File.FileName))
                using (var stream = System.IO.File.Create(pathAndFile))
                {
                    await File.CopyToAsync(localFile);
                }
            }
            UploadViewModel.url = redirectUrl;            
            UploadViewModel.FinancialYear = FinancialYear;
            return View(UploadViewModel);
        }
