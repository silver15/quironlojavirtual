using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.Models;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        private ProdutosRepositorio _repositorio;
        public int ProdutosPorPaginas = 3;
        // GET: Vitrine
        public ViewResult ListaProdutos(string categoria, int pagina  =1)
        {

            _repositorio = new ProdutosRepositorio();

            ProdutosViewModel model = new ProdutosViewModel()
            {

                Produtos = _repositorio.Produtos
                 .Where(p=>categoria == null || p.Categoria == categoria)
                .OrderBy(p => p.Descricao)
                .Skip((pagina - 1) * ProdutosPorPaginas)
                .Take(ProdutosPorPaginas),



                Paginacao = new Paginacao
                {
                    PaginaAtual = pagina,
                    ItensPorPagina = ProdutosPorPaginas,
                    ItensTotal = _repositorio.Produtos.Count()
                },

                CategoriaAtual = categoria
            };
          
            return View(model);
        }
    }
}