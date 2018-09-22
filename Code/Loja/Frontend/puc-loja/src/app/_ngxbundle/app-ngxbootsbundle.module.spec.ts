import { AppNgxbootsbundleModule } from './app-ngxbootsbundle.module';

describe('AppNgxbootsbundleModule', () => {
  let appNgxbootsbundleModule: AppNgxbootsbundleModule;

  beforeEach(() => {
    appNgxbootsbundleModule = new AppNgxbootsbundleModule();
  });

  it('should create an instance', () => {
    expect(appNgxbootsbundleModule).toBeTruthy();
  });
});
