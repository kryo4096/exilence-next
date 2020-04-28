import { inject, observer } from 'mobx-react';
import React from 'react';
import { SettingStore } from '../../../store/settingStore';
import NetWorthSettings from './NetWorthSettings';

interface Props {
  settingStore?: SettingStore;
}

const NetWorthSettingsContainer: React.FC<Props> = ({
  settingStore
}: Props) => {
  return (
    <NetWorthSettings
      lowConfidencePricing={settingStore!.lowConfidencePricing}
      priceTreshold={settingStore!.priceTreshold}
      stackPriceThreshold={settingStore!.stackPriceThreshold}
      setPriceTreshold={(value: number) => settingStore!.setPriceTreshold(value)}
      setStackPriceThreshold={(value: number) => settingStore!.setStackPriceThreshold(value)}
      setLowConfidencePricing={(value: boolean) => settingStore!.setLowConfidencePricing(value)}
    />
  );
};

export default inject('settingStore')(observer(NetWorthSettingsContainer));
