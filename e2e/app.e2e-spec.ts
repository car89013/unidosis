import { UnidosisPage } from './app.po';

describe('unidosis App', function() {
  let page: UnidosisPage;

  beforeEach(() => {
    page = new UnidosisPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
