import { DevicesControlPage } from './app.po';

describe('devices-control App', () => {
  let page: DevicesControlPage;

  beforeEach(() => {
    page = new DevicesControlPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
