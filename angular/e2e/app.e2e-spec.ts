import { OneAppHNITemplatePage } from './app.po';

describe('OneAppHNI App', function() {
  let page: OneAppHNITemplatePage;

  beforeEach(() => {
    page = new OneAppHNITemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
